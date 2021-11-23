using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Init : MonoBehaviour
{
    [SerializeField] GameObject start_Combat;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            start_Combat.SetActive(true);
        }
    }
}
