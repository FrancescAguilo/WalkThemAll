using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Init : MonoBehaviour
{
    [SerializeField] GameObject start_Combat;
    [SerializeField] GameObject Combate;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy_1")|| other.CompareTag("Enemy_2"))
        {
            start_Combat.SetActive(true);
            other.GetComponent<Enemy_type_1>().detected = true;

            Combate.GetComponent<startCapture>().enemyFormINT = other.GetComponent<Enemy_type_1>().enemyForm;
        }
    }
}
