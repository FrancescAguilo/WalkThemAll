using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Podomerter : MonoBehaviour
{
    public Text texto;



    private float loLim = 0.005F;
    private float hiLim = 0.3F;
    private int steps = 0;
    private bool stateH = false;
    private float fHigh = 8.0F;
    private float curAcc = 0F;
    private float fLow = 0.2F;
    private float avgAcc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = stepDetector().ToString();
    }

    public int stepDetector()
    {
        curAcc = Mathf.Lerp(curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
        avgAcc = Mathf.Lerp(avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
        float delta = curAcc - avgAcc;
        if (!stateH)
        {
            if (delta > hiLim)
            {
                stateH = true;
                steps++;
            }
        }
        else
        {
            if (delta < loLim)
            {
                stateH = false;
            }
        }
        avgAcc = curAcc;
        //calDistance(steps);

        return steps;
    }
}
