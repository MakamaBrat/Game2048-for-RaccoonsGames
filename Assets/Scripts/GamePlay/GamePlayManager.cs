using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/* GamePlayManager головний скріпт, який контрлює життєвий цикл програми.
він збегрігає в свобі посилання на деякі важливі частини програми як soundController, blockController, різні об'єкти
які мають в дочерних обьектах елементи інтферфейсу який потрібно вимкнути під час натику паузи
 * 
 * 
 * 
 * 
 * 
 */
public class GamePlayManager : MonoBehaviour
{
    public mainMenuUIController menuUIController;
    public ScoreManager scoreManager;
    public GameObject gamePlayUI;
    public BlockController blockController;
    public GameObject[] prefabBlock;
    public SoundController soundController;
    public List<GameObject> activeBlocks;
    private void Awake()
    {
        soundController = FindAnyObjectByType<SoundController>();
        activeBlocks = new List<GameObject>();
    }


    public void setReadyForBlockControl() // вмикаємо управління блоком для гравця
    {
        if (blockController.currentState != BlockController.BlockState.notClicked)
        {

            Debug.Log("SetReadyForBlockControl");
            int randomBlock = Random.Range(0, 4);
            GameObject block;
            if (randomBlock > 0)
            {
                block = Instantiate(prefabBlock[0]);
         
            }
            else { block = Instantiate(prefabBlock[1]); }
            activeBlocks.Add(block);
            blockController.movedBlock = block.GetComponent<Rigidbody>();
            blockController.setNotClicked();
        }
    }

    public void pauseGame()  // перемикач гри на паузу
    {

        menuUIController.transform.parent.transform.gameObject.SetActive(true);
        menuUIController.showPanel(4);
        blockController.setSliderPlayable(false);
        StopAllCoroutines();
        StartCoroutine(gamePauseTimer());
        soundController.playSoundUI(soundController.clickSound);
    }

    public void playGame()  // вимикаємо паузу
    {
        blockController.setSliderPlayable(true);
        StopAllCoroutines();
        Time.timeScale = 1;
        StartCoroutine(gamePauseTimerOff());
    }

    public void gameOverGame()  // метод який закінчує гру, та відображає результат
    {
        scoreManager.saveBestScore();
        menuUIController.transform.parent.transform.gameObject.SetActive(true);
        menuUIController.showPanel(5);
        StopAllCoroutines();
        StartCoroutine(gamePauseTimer());
        soundController.playSoundUI(soundController.clickSound);
        blockController.setSliderPlayable(false);
    }
    public void restartGame()// метод який підготавлює ігрове поле для наступної сесії
    {
        blockController.currentState = BlockController.BlockState.sleep;
        destroyAllBlocks();
        scoreManager.clearScore();
        blockController.setSliderPlayable(true);
        soundController.playSoundUI(soundController.clickSound);
        setReadyForBlockControl();

    }
    public void setNormalTime() // метод який встановлює нормальний час після паузи, потрібен для роботи Animator у меню
    {
        Time.timeScale = 1;
    }
    IEnumerator gamePauseTimer()  // коли вмикається пауза - чекає закінчення анімації
    {
        yield return new WaitForSeconds(0.05f);
        menuUIController.showPanel(4);
        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 0;
    }
    IEnumerator gamePauseTimerOff() // коли вимикається пауза - чекає закінчення анімації
    {
        yield return new WaitForSeconds(0.05f);
        menuUIController.showPanel(0);
        yield return new WaitForSeconds(0.35f);
        menuUIController.transform.parent.transform.gameObject.SetActive(false);
    }

    public void destroyAllBlocks() //чистить ігрове поле від блоків
    {
        foreach(GameObject bl in activeBlocks.ToArray())
        {
            Destroy(bl.gameObject);
            
        }
        activeBlocks.Clear();
    }

}
