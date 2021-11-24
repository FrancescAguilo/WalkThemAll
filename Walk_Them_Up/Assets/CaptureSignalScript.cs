using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureSignalScript : MonoBehaviour
{
    enum difficulty {EASY, MEDIUM,HARD};

    [SerializeField] difficulty dificultad;

    private void Awake()
    {
        if (dificultad == difficulty.EASY)
        {
            StartCoroutine("timerEasy");
        }
        else if(dificultad == difficulty.MEDIUM)
        {
            StartCoroutine("timerMed");
        }
        else
        {
            StartCoroutine("timerHard");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timerEasy()
    {
        yield return new WaitForSeconds(2);
        byeFunction();
    }

    IEnumerator timerMed()
    {
        yield return new WaitForSeconds(1);
        byeFunction();
    }

    IEnumerator timerHard()
    {
        yield return new WaitForSeconds(0.5f);
        byeFunction();
    }

    public void byeFunction()
    {
        StopCoroutine("timerEasy");
        StopCoroutine("timerMed");
        StopCoroutine("timerHard");
        Destroy(this, 0.1f);
    }

}
