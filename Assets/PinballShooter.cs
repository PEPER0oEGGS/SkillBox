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
        TimerShootCounter = TimerShoot;
    }



    void Update()
    {
        if (isWait)
        {
            TimerWaitCounter--;
            if (TimerWaitCounter == 0)
            {
                TimerWaitCounter = TimerWait;
                //sj.spring = 0;
                isWait = false;
            }
        }
        else
        {
             rb.AddRelativeForce(new Vector3(0, 0, -1) * Force, ForceMode.Force);
            //sj.spring = 50000000; 
            isWait = true;
        }
    }
}
