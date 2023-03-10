using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� ������� �� ��������� ������� ��'����� �������

public class BlockController : MonoBehaviour
{

    public Rigidbody movedBlock;
    public Slider sliderSide;
    public Slider sliderPower;
    public NextTimeWaiter nextTimeWaiter;
    private Vector3 startPosition;
    public float moveSpeed = 5f; // �������� ��������� ��'����
    public float powerBlockKof;
    public enum BlockState { notClicked, clicked, sleep } // ������� �� �� ����� �� �������, ������� ����� �� �������, ����� ����
    private float timeElapsed = 0f;
    private bool isIncreasing = true;
    [SerializeField] public BlockState currentState;
    SoundController soundController;
    private void Awake()
    {
        currentState = BlockState.sleep;
        soundController = FindAnyObjectByType<SoundController>();
    }
    private void FixedUpdate()
    {
        if (currentState != BlockState.sleep) // �������� ��'��� ���� ������� ������� ���� ��� �������
        {
            float movement = sliderSide.value; 
            Vector3 newPosition = transform.position + new Vector3((movement * moveSpeed) - 2.60f, 0, 0f) / 1.9f; 

            movedBlock.transform.position = new Vector3(newPosition.x, -1.8f, -2); 
        }
    }

    private void Update()
    {
        if(currentState==BlockState.notClicked)
        {
            sliderLoopChange(sliderSide);
        }
        else if (currentState == BlockState.clicked)
        {
            sliderLoopChange(sliderPower);
        }
        
        if(Input.GetMouseButtonUp(0) && currentState == BlockState.clicked) // ������� �������� ������
        {
            pushBlockForward();
            currentState = BlockState.sleep;
        }
    }

    public void sliderLoopChange(Slider slider)
    {
        float sliderValue = Mathf.Lerp(0f, 1f, timeElapsed ); 

        slider.value = sliderValue; 
     
        if (isIncreasing)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 1f) 
            {
                isIncreasing = false;
                timeElapsed = 1f;
            }
        }
        else
        {
            timeElapsed -= Time.deltaTime;
            if (timeElapsed <= 0f) // 
            {
                isIncreasing = true;
                timeElapsed = 0f;
            }
        }
    }
  
    public void sliderClick()
    {
        if (currentState == BlockState.notClicked)
        { currentState = BlockState.clicked; }

    }

    public void pushBlockForward() 
    {
        soundController.playSoundUI(soundController.pushSound);
        movedBlock.isKinematic = false;
        movedBlock.useGravity = true;
        movedBlock.AddForce(movedBlock.transform.forward*sliderPower.value*powerBlockKof+new Vector3(0,0,250));
        nextTimeWaiter.timerStartOrReseting();
    }

    public void setNotClicked()
    {
        currentState = BlockState.notClicked;
    }

    public void setSliderPlayable(bool on)
    {
        sliderSide.interactable = on;
    }
    
}
