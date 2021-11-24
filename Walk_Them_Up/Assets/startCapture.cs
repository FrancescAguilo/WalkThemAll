using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCapture : MonoBehaviour
{
    [SerializeField] GameObject capturePointsPF;
    [SerializeField] GameObject Player;
    public int tiempoEntreBolas = 1;
    public int numGenerated = 5;
    List<Vector3> positions = new List<Vector3>();

    int minValueX = 5;
    int maxValueX = 5;

    int minValueZ = 3;
    int maxValueZ = 3;
    bool empezada = false;

    // Start is called before the first frame update
    void Start()
    {
       
        positions = generatePositions(numGenerated);
        Debug.Log("1");

    }

    // Update is called once per frame
    void Update()
    {
        //caso estandar
        if (true)
        {
            //spawnear 5 con 1 seg de delay
            if (!empezada)
            {
                Debug.Log("2");
                StartCoroutine("generateCapturePoints");
            }
        }
     
    }


    IEnumerator generateCapturePoints()
    {
        empezada = true;
        
        for (int i = 0; i < numGenerated; i++)
        {
            Instantiate(capturePointsPF, positions[i], Quaternion.identity);
           
            yield return new WaitForSeconds(1);
            
        }
        stopCorroutines();
    }

    public void stopCorroutines()
    {
        StopCoroutine("generateCapturePoints");
        //igual poner a false empezada o algo ya se vera
    }

    //Generamos todas las posiciones donde se crearan las bolas
    public List<Vector3> generatePositions(int howManyPositions)
    {
        List<Vector3> posiciones = new List<Vector3>();
        Vector3 aux;
        

        for(int i = 0; i < howManyPositions; i++)
        {
            aux.x = Random.Range(Player.transform.position.x - minValueX, Player.transform.position.x + maxValueX);
            aux.y = Player.transform.position.y;
            aux.z = Random.Range(Player.transform.position.z - minValueZ, Player.transform.position.z + maxValueZ);

            posiciones.Add(aux);
        }
        
        return posiciones;
    }
}
