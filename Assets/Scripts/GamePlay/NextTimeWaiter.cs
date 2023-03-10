using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// клас який перевіряє чи закінчилась активність ігрових об'єктів після ходу
public class NextTimeWaiter : MonoBehaviour
{

    public float waitingTime;
    public UnityEvent nextTimeAct;
    public BlockController blockController;
    public GamePlayManager gamePlayManager;
    void Start()
    {

    }


    void Update()
    {

    }

    
    public void timerStartOrReseting()
    {
        if (blockController.currentState != BlockController.BlockState.notClicked)
        {
            StopAllCoroutines();
            StartCoroutine(timerForNext());
        }
    }

    IEnumerator timerForNext()
    {
        yield return new WaitForSeconds(waitingTime);
        if (blockController.currentState != BlockController.BlockState.notClicked)
        {
            gamePlayManager.setReadyForBlockControl();
        }

    }
}
