using UnityEngine;

public class StateMachine : MonoBehaviour
{

    [SerializeField] private Canvas _pause;
    [SerializeField] private Canvas _postcombat;


    public void Pause(bool setPause)
    {
        if (setPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        _pause.enabled = setPause;
    }

    public void Postcombat(bool setPostconbat)
    {
        _postcombat.enabled = setPostconbat;
    }

}
