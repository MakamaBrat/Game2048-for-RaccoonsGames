using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyAfterTimer : MonoBehaviour
{
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timerDestroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
