using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextFieldUpdater _resourses;
    [SerializeField] private TextFieldUpdater _raids;
    [SerializeField] private TextFieldUpdater _postcombat;
    [SerializeField] private int _farmerCount = 3;
    [SerializeField] private int _warriorCount = 0;
    [SerializeField] private int _eatCount = 10;
    [SerializeField] private int _eatPerFarmer = 3;
    [SerializeField] private int _eatToWarrior = 3;
    [SerializeField] private int _farmerCreateCost = 3;
    [SerializeField] private int _warriorCreateCost = 8;
    [SerializeField] private int _farmerCreateTime = 1;
    [SerializeField] private int _warriorCreateTime = 4;
    [SerializeField] private int _harvestTime = 5;
    [SerializeField] private int _raidMaxTime = 60;
    [SerializeField] private int _eatTime = 13;
    [SerializeField] private int _raidIncrease = 2;
    [SerializeField] private int _nextRaid = 0;
    [SerializeField] private int _safeRaid = 3;
    [SerializeField] private int _eatToWin = 4000;
    [SerializeField] private int _farmerToWin = 125;

    private bool[] _battonsState = { true, true };
    private int _raidCounter = 0;
    private int _warriorTotalCounter = 0;
    private int _deadWarriorTotalCounter = 0;
    private int _eatTotalCounter = 0;

    private int _startFermers;
    private int _startWarriors;
    private int _startEat;
    private int _startSafeRaid;

    private void Start()
    {
        UpdateTextResourses();
        UpdateTextRaid();
        GetComponent<TimersController>().DefoultSetings(new float[] { _harvestTime, _raidMaxTime, _eatTime, _farmerCreateTime, _warriorCreateTime });
        GetComponent<TimersController>().SetTimerState(new int[] { 1, 1, 1, 3, 3 });
        _startFermers = _farmerCount;
        _startWarriors = _warriorCount;
        _startEat = _eatCount;
        _startSafeRaid = _safeRaid;
    }

    private void Update()
    {
        if (_eatCount >= _eatToWin && _farmerCount >= _farmerToWin)
        {
            Postcombat(true);
            Time.timeScale = 0;
        }   
    }

    public void Restart()
    {
        _farmerCount = _startFermers;
        _warriorCount = _startWarriors;
        _eatCount = _startEat;
        _safeRaid = _startSafeRaid;
        _raidCounter = 0;
        _warriorTotalCounter = 0;
        _deadWarriorTotalCounter = 0;
        _eatTotalCounter = 0;
        _battonsState = new bool[] { true, true };
        UpdateTextResourses();
        UpdateTextRaid();
        GetComponent<TimersController>().DefoultSetings(new float[] { _harvestTime, _raidMaxTime, _eatTime, _farmerCreateTime, _warriorCreateTime });
        GetComponent<TimersController>().SetTimerState(new int[] { 1, 1, 1, 3, 3 });
        GetComponent<StateMachine>().Postcombat(false);
        Time.timeScale = 1;
    }

    public void GetWarrior()
    {
        _eatCount -= _warriorCreateCost;
        _battonsState[1] = false;
        GetComponent<TimersController>().SetTimerState(new int[] { 0, 0, 0, 0, GetComponent<TimersController>().WorkState() });
        UpdateTextResourses();
    }

    public void GetFarmer()
    {
        _eatCount -= _farmerCreateCost;
        _battonsState[0] = false;
        GetComponent<TimersController>().SetTimerState(new int[] { 0, 0, 0, GetComponent<TimersController>().WorkState() });
        UpdateTextResourses();
    }

    public void AddFarmer()
    {
        _farmerCount++;
        _battonsState[0] = true;
        UpdateTextResourses();
    }

    public void AddWarrior()
    {
        _warriorCount++;
        _warriorTotalCounter++;
        _battonsState[1] = true;
        UpdateTextResourses();
    }

    public void CheckFarmerButton()
    {
        float raidCurrentTime = GetComponent<TimersController>().GetTimerCurrentTime()[1];
        if (_eatCount + _farmerCount * _eatPerFarmer * (raidCurrentTime / _harvestTime) - +_warriorCount * _eatToWarrior * (raidCurrentTime / _eatTime) < _farmerCreateCost || _eatCount < _farmerCreateCost)
        {
            _battonsState[0] = false;
        }
        else
        {
            _battonsState[0] = true;
        }
    }

    public void CheckWarriorButton()
    {
        float raidCurrentTime = GetComponent<TimersController>().GetTimerCurrentTime()[1];
        if (_eatCount + _farmerCount * _eatPerFarmer * (raidCurrentTime / _harvestTime) - +_warriorCount * _eatToWarrior * (raidCurrentTime / _eatTime) < _warriorCreateCost || _eatCount < _warriorCreateCost)
        {
            _battonsState[1] = false;
        }
        else
        {
            _battonsState[1] = true;
        }

    }

    public void GetHarvest()
    {
        _eatCount += _farmerCount * _eatPerFarmer;
        _eatTotalCounter += _farmerCount * _eatPerFarmer;
        UpdateTextResourses();
    }

    public void WarriorEating()
    {
        _eatCount -= _warriorCount * _eatToWarrior;
        UpdateTextResourses();
    }

    public void RaidFight()
    {

        if (_safeRaid > 0)
        {
            _safeRaid--;

        }
        else
        {
            _nextRaid += _raidIncrease;
        }
        _warriorCount -= _nextRaid;
        _deadWarriorTotalCounter += _nextRaid;
        if (_warriorCount < 0)
        {
            _deadWarriorTotalCounter += _warriorCount;
            Postcombat(false);
            Time.timeScale = 0;
        }
        _raidCounter++;
        UpdateTextResourses();
        UpdateTextRaid();
    }

    public bool[] GetButtonsState()
    {
        return _battonsState;
    }

    private void UpdateTextResourses()
    {
        _resourses.TextUpdate(new string[] { _farmerCount.ToString(), _warriorCount.ToString(), _eatCount.ToString() });
    }

    private void UpdateTextRaid()
    {
        _raids.TextUpdate(new string[] { _raidCounter.ToString(), (_nextRaid + _raidIncrease).ToString(), "Рейдов разведки: " + _safeRaid.ToString() });
    }

    private void Postcombat(bool isWin)
    {
        if (isWin)
        {
            _postcombat.TextUpdate(new string[] { "Вы победили!", _raidCounter.ToString(), _eatTotalCounter.ToString(), _warriorTotalCounter.ToString(), _deadWarriorTotalCounter.ToString(), (_farmerCount - _startFermers).ToString() });

        }
        else
        {
            _postcombat.TextUpdate(new string[] { "Вы проиграли", _raidCounter.ToString(), _eatTotalCounter.ToString(), _warriorTotalCounter.ToString(), _deadWarriorTotalCounter.ToString(), (_farmerCount - _startFermers).ToString() });
        }
        GetComponent<StateMachine>().Postcombat(true);
    }
}
