using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/* GamePlayManager �������� �����, ���� �������� ������� ���� ��������.
�� ������� � ���� ��������� �� ���� ������ ������� �������� �� soundController, blockController, ��� ��'����
�� ����� � �������� �������� �������� ����������� ���� ������� �������� �� ��� ������ �����
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


    public void setReadyForBlockControl() // ������� ��������� ������ ��� ������
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

    public void pauseGame()  // ��������� ��� �� �����
    {

        menuUIController.transform.parent.transform.gameObject.SetActive(true);
        menuUIController.showPanel(4);
        blockController.setSliderPlayable(false);
        StopAllCoroutines();
        StartCoroutine(gamePauseTimer());
        soundController.playSoundUI(soundController.clickSound);
    }

    public void playGame()  // �������� �����
    {
        blockController.setSliderPlayable(true);
        StopAllCoroutines();
        Time.timeScale = 1;
        StartCoroutine(gamePauseTimerOff());
    }

    public void gameOverGame()  // ����� ���� ������ ���, �� �������� ���������
    {
        scoreManager.saveBestScore();
        menuUIController.transform.parent.transform.gameObject.SetActive(true);
        menuUIController.showPanel(5);
        StopAllCoroutines();
        StartCoroutine(gamePauseTimer());
        soundController.playSoundUI(soundController.clickSound);
        blockController.setSliderPlayable(false);
    }
    public void restartGame()// ����� ���� ���������� ������ ���� ��� �������� ���
    {
        blockController.currentState = BlockController.BlockState.sleep;
        destroyAllBlocks();
        scoreManager.clearScore();
        blockController.setSliderPlayable(true);
        soundController.playSoundUI(soundController.clickSound);
        setReadyForBlockControl();

    }
    public void setNormalTime() // ����� ���� ���������� ���������� ��� ���� �����, ������� ��� ������ Animator � ����
    {
        Time.timeScale = 1;
    }
    IEnumerator gamePauseTimer()  // ���� ��������� ����� - ���� ��������� �������
    {
        yield return new WaitForSeconds(0.05f);
        menuUIController.showPanel(4);
        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 0;
    }
    IEnumerator gamePauseTimerOff() // ���� ���������� ����� - ���� ��������� �������
    {
        yield return new WaitForSeconds(0.05f);
        menuUIController.showPanel(0);
        yield return new WaitForSeconds(0.35f);
        menuUIController.transform.parent.transform.gameObject.SetActive(false);
    }

    public void destroyAllBlocks() //������� ������ ���� �� �����
    {
        foreach(GameObject bl in activeBlocks.ToArray())
        {
            Destroy(bl.gameObject);
            
        }
        activeBlocks.Clear();
    }

}
