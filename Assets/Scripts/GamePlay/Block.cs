using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// Клас який описує сутніть ігрової одиниці Блок з числом
public class Block : MonoBehaviour
{
    public float value;
    public BlockType blockType;
    public enum BlockType { type2,type4, type8,type16,type32,type64,type128,type256,type512,type1024,type2048 };

    public TMP_Text[] textValue;
    Rigidbody rb;
    SoundController soundController;
    public GameObject explousionPrefab;
    private GamePlayManager gamePlayManager;
    public bool isCollided;
    private void Awake()
    {
        isCollided = false;
        rb = gameObject.GetComponent<Rigidbody>();
        soundController = FindAnyObjectByType<SoundController>();
        gamePlayManager = FindAnyObjectByType<GamePlayManager>();
    }
    void Start()
    {
        updateTextValue();
    }

    void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            { gamePlayManager.gameOverGame();
                Destroy(gameObject);
            }
        }
    }

    public void updateTextValue()
    {
        foreach(TMP_Text text in textValue)
        {
            text.text = value.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

      
        if (collision.gameObject.tag == "Block")
        {
            Rigidbody collisionRb = collision.gameObject.GetComponent<Rigidbody>();
             Block collisionBlock = collision.gameObject.GetComponent<Block>();
            if (collisionRb.isKinematic)
            { Destroy(gameObject); }
            if (!isCollided && blockType == collisionBlock.blockType && ((int)blockType)<gamePlayManager.prefabBlock.Length)
            {
                isCollided = true;


               
                

               
                if (rb.velocity.magnitude > 2 && collisionBlock.isCollided)
                {

                    Destroy(collision.gameObject);
                    
                    var createdBlock = Instantiate(gamePlayManager.prefabBlock[((int)blockType) + 1], transform.position, transform.rotation, null);
                    gamePlayManager.scoreManager.setScore(((int)blockType) +1);
                    gamePlayManager.activeBlocks.Add(createdBlock);
                    Instantiate(explousionPrefab, transform.position, transform.rotation, null);
                    Rigidbody createdBlockRb = createdBlock.GetComponent<Rigidbody>();
                    createdBlockRb.isKinematic = false;
                    createdBlockRb.useGravity = true;
                    isCollided = false;
                    Destroy(gameObject);
                    soundController.playSoundUI(soundController.goodHitSound);
                }
               


            }
        }
        else { soundController.playSoundGameplay(soundController.badHitSound); }
    }

  
}
