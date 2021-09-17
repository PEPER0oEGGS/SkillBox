using UnityEngine;
using UnityEngine.UI;

public class TimersController : MonoBehaviour
{
    [SerializeField] private Image[] _timers;
    private const int stopState = 3;
    private const int finishState = 2;
    private const int workState = 1;
    private GameManager _gm;

    public void Start()
    {
        _gm = GetComponent<GameManager>();
    }

    public void Update()
    {
        int[] timersStates = GetTimersState();
        if (timersStates[0] == 2)
        {
            _gm.GetHarvest();
            timersStates[0] = WorkState();
        }
        if (timersStates[1] == 2)
        {
            _gm.RaidFight();
            timersStates[1] = WorkState();
        }
        if (timersStates[2] == 2)
        {
            _gm.WarriorEating();
            timersStates[2] = WorkState();
        }
        if (timersStates[3] == 2)
        {
            _gm.AddFarmer();
            timersStates[3] = GetComponent<TimersController>().StopState();
        }
        if (timersStates[4] == 2)
        {
            _gm.AddWarrior();
            timersStates[4] = GetComponent<TimersController>().StopState();
        }
        if (timersStates[3] == 3)
        {
            _gm.CheckFarmerButton();
        }
        if (timersStates[3] == 3)
        {
            _gm.CheckWarriorButton();
        }
        SetTimerState(timersStates);
    }
    public int[] GetTimersState()
    {
        int[] timersStates = new int[_timers.Length];
        for (int i = 0; i < _timers.Length; i++)
        {
            timersStates[i] = _timers[i].GetComponent<ImageTimer>().CheckState();
        }
        return timersStates;
    }

    /// <summary>
    /// if timerMaxTime[n] = 0 - Scip timer
    /// </summary>
    /// <param name="state"></param>
    public void SetTimerState(int[] state)
    {
        for (int i = 0; i < _timers.Length && i < state.Length; i++)
        {
            if (state[i] != 0)
            {
                _timers[i].GetComponent<ImageTimer>().SetState(state[i]);
            }
        }

    }

    /// <summary>
    /// if timerMaxTime[n] = 0 - Scip timer
    /// </summary>
    /// <param name="timerMaxTime"></param>
    public void DefoultSetings(float[] timerMaxTime)
    {
        for (int i = 0; i < _timers.Length && i < timerMaxTime.Length; i++)
        {
            if (timerMaxTime[i] != 0)
            {
                _timers[i].GetComponent<ImageTimer>().SetMaxTime(timerMaxTime[i]);
            }
        };
    }

    public float[] GetTimerCurrentTime()
    {
        float[] timersTime = new float[_timers.Length];
        for (int i = 0; i < _timers.Length; i++)
        {
            timersTime[i] = _timers[i].GetComponent<ImageTimer>().GetCurrentTime();
        }
        return timersTime;

    }

    public int StopState()
    {
        return stopState;
    }

    public int FinishState()
    {
        return finishState;
    }

    public int WorkState()
    {
        return workState;
    }

}
