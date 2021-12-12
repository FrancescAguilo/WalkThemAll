using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_type_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EnemyType {Enemy1,Enemy2,Enemy3 };
   
    public int[] enemyForm;

    public EnemyType type;
    public ParticleSystem particleSystem;
    private Transform player;
    private NavMeshAgent ai;
    public bool detected = false;

    private float timer;
    void Start()
    {
        enemyForm = GenerateEnemyType();
        particleSystem.Play();
        timer = Random.Range(10, 25);
        player = GameObject.Find("Luis Adrian").transform;
        ai = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!detected)
        {
            if (Vector3.Distance(this.transform.position, player.position) < 20)
            {
                switch (type)
                {
                    case EnemyType.Enemy1:

                        Vector3 dir = transform.position - player.position;
                        Vector3 newPos = transform.position + dir;
                        ai.SetDestination(newPos);

                        break;

                    case EnemyType.Enemy2:

                        ai.SetDestination(transform.position);
                        break;
                    case EnemyType.Enemy3:

                        break;
                }
            }

            if (timer < 0)
            {
                Destroy(gameObject);
            }
            else
            {
                timer -= Time.deltaTime;
            }




        }
        else
        {
            Destroy(this.gameObject, 0.25f);
        }
    }

    public int[] GenerateEnemyType()
    {
        int[] aux = new int[4];
        int random = 0;

        for(int i = 0; i < 4; i++)
        {
            random = Random.Range(0, 3);
            if (random == 2)
            {
                random++;
            }
            aux[i] = random;
        }

        return aux;
    }
}
