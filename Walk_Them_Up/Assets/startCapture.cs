using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCapture : MonoBehaviour
{
    [SerializeField] GameObject capturePointsPF;
    [SerializeField] GameObject Player;
    public int tiempoEntreBolas = 1;
    public int numGenerated = 5;
    List<Vector3> positions;

    int minValue = 5;
    int maxValue = 5;
    bool empezada = false;

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> positions = new List<Vector3>();
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
            aux.x = Random.Range(Player.transform.position.x - minValue, Player.transform.position.x + maxValue);
            aux.y = Player.transform.position.y;
            aux.z = Random.Range(Player.transform.position.z - minValue, Player.transform.position.z + maxValue);

            posiciones.Add(aux);
        }

        return posiciones;
    }
}
