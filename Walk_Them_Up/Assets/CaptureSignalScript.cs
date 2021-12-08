using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureSignalScript : MonoBehaviour
{
    enum difficulty {EASY, MEDIUM,HARD};

    [SerializeField] difficulty dificultad;

    [SerializeField] Button btn;
    [SerializeField] ParticleSystem ps;
    

    private void Awake()
    {
        ps.Stop();

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
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        ps.Play();
        byeFunction(0.1f);
    }

    IEnumerator timerEasy()
    {
        yield return new WaitForSeconds(2);
        //Debug.Log("Deberia borrarme ahora padre");
        byeFunction(0.1f);
    }

    IEnumerator timerMed()
    {
        yield return new WaitForSeconds(1);
        byeFunction(0.1f);
    }

    IEnumerator timerHard()
    {
        yield return new WaitForSeconds(0.5f);
        byeFunction(0.1f);
    }

    public void byeFunction(float time)
    {
        StopCoroutine("timerEasy");
        StopCoroutine("timerMed");
        StopCoroutine("timerHard");
        Destroy(this.gameObject, time);
    }

}
