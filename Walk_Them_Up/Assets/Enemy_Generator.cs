using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    public GameObject [] enemy;
   
    void Start()
    {
        timer = Random.Range(5, 25);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <0)
        {

            Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(this.transform.position.x + Random.Range(-10, 10), 1012, this.transform.position.z + Random.Range(10,40)), Quaternion.identity);
            timer = Random.Range(5, 25);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
