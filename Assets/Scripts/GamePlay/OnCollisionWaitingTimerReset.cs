using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionWaitingTimerReset : MonoBehaviour
{
    NextTimeWaiter timeWaiter;
    private void Awake()
    {
        timeWaiter = GameObject.FindAnyObjectByType<NextTimeWaiter>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        timeWaiter.timerStartOrReseting();
    }
}
