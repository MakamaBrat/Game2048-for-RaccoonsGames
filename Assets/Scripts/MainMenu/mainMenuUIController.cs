using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuUIController : MonoBehaviour
{
      
    /*   цей клас управляє вікнами інтерфейсу з анімацією.
     *   
     * 
     * 
     * 
     * 
     */

    public Animator[] panelAnimator;
    public GamePlayManager gamePlayManager;
    public GameObject gamePlayBoards;
    public GameObject gamePlayUI;
    private int currentPanel;
    private bool canClick;
    SoundController soundController;


    private void Awake()
    {
        soundController = FindAnyObjectByType<SoundController>();
    }
    void Start()
    {
        setPanelsDefaultPositions();

    }

    public void setPanelsDefaultPositions() //перше положення меню
    {
        foreach(Animator panel in panelAnimator)
        {
            panel.gameObject.SetActive(false);
        }
        panelAnimator[0].gameObject.SetActive(true);
        currentPanel = 0;
        canClick = true;
    }
    public void showPanel(int index) //головний метод для управління вікнами інтерфейсу
    {
        if (!canClick)
            return;
        canClick = false;

        panelAnimator[currentPanel].SetInteger("state",0); // 0 close 1 state 2 open
        StartCoroutine(panelDisableCoroutine(currentPanel));
        panelAnimator[index].gameObject.SetActive(true);
        panelAnimator[index].transform.SetAsFirstSibling();
        panelAnimator[index].SetInteger("state", 2);
        currentPanel = index;
        soundController.playSoundUI(soundController.clickSound);

    }

    


    IEnumerator panelDisableCoroutine(int index)  //для правильної роботи анімації чекаємо поки обьект опуститься до низу а потім вимикаємо його
    { 
        yield return new WaitForSeconds(0.25f);
        canClick = true;
        panelAnimator[index].gameObject.SetActive(false);
       
    }

    public void startGame() //метод для початку гри
    {
      
        gameObject.transform.parent.gameObject.SetActive(false);
        gamePlayBoards.SetActive(true);
        gamePlayUI.SetActive(true);

        gamePlayManager.restartGame();
        
    }

    public void gameExit()
    {
        Application.Quit();
    }
}
