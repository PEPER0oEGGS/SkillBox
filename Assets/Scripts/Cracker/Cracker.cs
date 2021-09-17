using UnityEngine;
using UnityEngine.UI;

public class Cracker : MonoBehaviour
{

    [SerializeField] private Text _timeText;
    [SerializeField] private Text _mesageText;
    private LocksControler _locksC;
    private bool _isTimeMode = true;
    private float _startTime;
    private float _timeToGame = 20;

    private void Start()
    {
        _locksC = this.GetComponent<StateMashineCr>().GetLocksController();
        Restart();
    }

    private void Update()
    {
        if (_isTimeMode)
        {
            _startTime = (_startTime - Time.deltaTime);
            _timeText.text = Mathf.Round(_startTime).ToString();
            if (_startTime <= 0)
            {
                this.GetComponent<StateMashineCr>().ScreenState("Loze");
            }
        }
    }

    public void Restart()
    {

        _locksC.ResetLocks();
        this.GetComponent<StateMashineCr>().ScreenState("Game");

        if (_isTimeMode)
        {
            _startTime = _timeToGame;
            _mesageText.text = "Времени осталось: ";
            _timeText.text = Mathf.Round(_timeToGame).ToString();
        }
        else
        {
            _mesageText.text = "Действий осталось: ";
        }

    }

    public void ChangeMod()
    {
        _isTimeMode = !_isTimeMode;
        Restart();
    }

    public void TryShow(string text)
    {
        if (!_isTimeMode)
        {
            _timeText.text = text;
        }
    }

    public void Win()
    {
        this.GetComponent<StateMashineCr>().ScreenState("Win");
    }

    public void Loze()
    {
        if (!_isTimeMode)
        {
            this.GetComponent<StateMashineCr>().ScreenState("Loze");
        }
    }
}

