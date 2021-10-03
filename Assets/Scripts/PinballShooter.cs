using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballShooter : MonoBehaviour
{
    [SerializeField] private float Force = 1000;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SpringJoint sj;
    [SerializeField] private float TimerWait = 1000;
    [SerializeField] private float TimerShoot = 1000;
    private float TimerWaitCounter;
    private float TimerShootCounter;
    private bool isWait = true;
    void Start()
    {
        TimerWaitCounter = TimerWait;
        sj.tolerance = 2;
        TimerShootCounter = TimerShoot;
    }
    void Update()
    {
        TimerWaitCounter--;
        if (isWait)
        {
            rb.AddRelativeForce(new Vector3(0, 0, -1) * Force * Time.deltaTime, ForceMode.Force);
            if (TimerWaitCounter == 0)
            {
                TimerWaitCounter = TimerWait;
                Debug.Log(sj.tolerance);
                sj.tolerance = 0f;
                
                isWait = false;
            }
        }
        else
        {
            if (TimerWaitCounter == 0)
            {
                TimerWaitCounter = TimerWait;
                Debug.LogError(sj.tolerance);
                sj.tolerance = 2f;

                isWait = true;
            }
        }
    }
}
