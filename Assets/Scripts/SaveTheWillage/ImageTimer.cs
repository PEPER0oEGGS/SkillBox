using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{

    private float _maxTime;
    private float _timer;
    private int _TimerState = 3;
    private AudioSource _audio;

    private void Update()
    {
        if (_TimerState == 1)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _timer = _maxTime;
                _TimerState = 2;
                if (_audio != null)
                {
                    _audio.Play();
                }
            }
            GetComponent<Image>().fillAmount = _timer / _maxTime;
        }
    }

    public void SetMaxTime(float maxTime)
    {
        _maxTime = maxTime;
        _timer = _maxTime;
        GetComponent<Image>().fillAmount = 1;
    }

    /// <summary>
    /// States: 1 - TimerWork | 2 - TimerLost 3 - TimerDisable 
    /// </summary>
    /// <param name="isTimerStart"></param>
    public void SetState(int state)
    {
        _TimerState = state;
    }

    public int CheckState()
    {
        return _TimerState;
    }

    public float GetCurrentTime()
    {
        return _timer;
    }

    public void SetAudiosourse(AudioSource audio)
    {
        _audio = audio;
    }
}
