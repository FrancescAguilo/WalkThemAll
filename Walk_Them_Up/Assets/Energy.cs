using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Podomerter pedometer;
    public Text energynumber;
    public Slider energySlider;
    private int aux;
    public int energy =0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Exchange_Steps()
    {
        if (energy < 25 && pedometer.steps / 100 >1)
        {

       
            print(pedometer.steps);
            energy += pedometer.steps / 100;

            aux = pedometer.steps;
            pedometer.steps = 0;
            if (energy > 25)
            {

                pedometer.steps =  (energy - 25) *100 ;
                 energy = 25;
            }
            pedometer.steps += aux % 100;
            energySlider.value += energy;
            energynumber.text = energySlider.value.ToString();
        }

    }

    public void Use_Energy()
    {
        energy -= 5;
        energySlider.value = energy;
        energynumber.text = energy.ToString();
    }
}
