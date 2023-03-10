using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreGetterFromeSave : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>(); 
    }
    private void OnEnable()
    {

        if(PlayerPrefs.HasKey("BestScore"))
        {
            text.text = "BestScore: " + PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            text.text = "BestScore: 0" ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
