using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class startCapture : MonoBehaviour
{
    public enum Type { TRIANGULO = 3, CUADRADO = 4, PENTAGONO = 5, CIRCULO = 8 };

    [SerializeField] GameObject capturePointsPF;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject myCanvas;
    //public int tiempoEntreBolas = 1;
    //public int numGenerated = 5;

    List<Vector3> positions = new List<Vector3>();
    
    public Type[] enemyForm;
    //public List<Type> enemyForm = new List<Type>();
    //List<Type> enemyForm = new List<Type>();
    //Type[] enemyForm;

    SortedDictionary<int, List<Vector3>> pointsPositions = new SortedDictionary<int, List<Vector3>>();

    int minValueX = 5;
    int maxValueX = 5;

    int minValueZ = 3;
    int maxValueZ = 3;

    bool gizmo = false;
    bool fin = true;

    //button
    int minValueBX = -625;
    int maxValueBX = 625;
    int minValueBY = -1540;
    int maxValueBY = 520;
    bool empezada = false;
    bool empezada2 = false;

    [Header("Triangulo:")]
    [Header("Magnitudes de las figuras geométricas:")]
    [Tooltip("Magnitud en X del triangulo")]
    public int tMX = 500; //triangleMagnitude on X 
    [Tooltip("Magnitud en Y del triangulo")]
    public int tMY = 500; //triangleMagnitude on Y

    //square
    [Header("Cuadrado:")]
    [Tooltip("Magnitud de lado")]
    public int sM = 800; //squareMagnitude

    //circle
    [Header("Circulo:")]
    [Tooltip("Radio del circulo")]
    public int radius = 500;
    [Tooltip("Variacion maxima que se suma/resta al radio del circulo")]
    public int randomVariation = 200;


    // Start is called before the first frame update
    void Start()
    {

        //positions = generatePositions(numGenerated);
        //Debug.Log("1");
        pointsPositions = generateGeometricPositions();


    }

    // Update is called once per frame
    void Update()
    {
      
            
        if (!empezada2)
        {

            //Debug.Log("2");
            //StartCoroutine("generatorManager");
            StartCoroutine("generateCapturePoints");
        }

        

    }

    //IEnumerator generatorManager()
    //{
    //    empezada2 = true;
    //    int i = 0;
    //    while (i < 4)
    //    {
    //        if (!empezada)
    //        {
    //            Debug.Log("soy la rutina " + i);
    //            StartCoroutine("generateCapturePoints");
    //            yield return new WaitForSeconds(3);
    //            //pointsPositions = generateGeometricPositions();
    //            i++;
    //        }
    //        Debug.Log("ahora espero a que " + i + " acabe");
    //    }
    //    stopCorroutines();
    //}


    IEnumerator generateCapturePoints()
    {

        empezada2 = true;
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log("ahora empiezo: " + pointsPositions[i].Count);
            int aux = i;
            //GameObject newButton = Instantiate(capturePointsPF, positions[i], Quaternion.identity) as GameObject;
            //List<Vector3> count = pointsPositions[i];
            


            for (int j = 0; j < pointsPositions[i].Count; j++)
            {
                GameObject newButton = Instantiate(capturePointsPF, pointsPositions[i][j], Quaternion.identity) as GameObject;
                aux = 1 + j;
                newButton.GetComponentInChildren<Text>().text = aux.ToString();
                
                newButton.transform.SetParent(myCanvas.transform, false);

           
            }
            yield return new WaitForSeconds(3);
            //Debug.Log("Ahora Espero 10 secs");
        }

        empezada = true;
        fin = false;
        stopCorroutines();
    }

    

    public void stopCorroutines()
    {
        StopCoroutine("generateCapturePoints");
        StopCoroutine("generatorManager");
        fin = true;
        empezada = false;
        empezada2 = false;
        this.gameObject.SetActive(false);
    }

    //Generamos todas las posiciones donde se crearan las bolas
    public List<Vector3> generatePositions(int howManyPositions)
    {
        List<Vector3> posiciones = new List<Vector3>();
        Vector3 aux;


        //for(int i = 0; i < howManyPositions; i++)
        //{
        //    aux.x = Random.Range(Player.transform.position.x - minValueX, Player.transform.position.x + maxValueX);
        //    aux.y = Player.transform.position.y;
        //    aux.z = Random.Range(Player.transform.position.z - minValueZ, Player.transform.position.z + maxValueZ);

        //    posiciones.Add(aux);
        //}

        for (int i = 0; i < howManyPositions; i++)
        {
            aux.x = Random.Range(minValueBX, maxValueBX);
            aux.y = Random.Range(minValueBY, maxValueBY);
            aux.z = 0;

            posiciones.Add(aux);
        }

        return posiciones;
    }

    public Vector3 generateRandomPoint(Vector2 aprox_vX, Vector2 aprox_vY)
    {
        //return new Vector3(Random.Range(-250, 50), Random.Range(-390, 90), 0);
        return new Vector3(Random.Range(aprox_vX.x, aprox_vX.y), Random.Range(aprox_vY.x, aprox_vY.y), 0);

    }

    public SortedDictionary<int, List<Vector3>> generateGeometricPositions()
    {
        //int nPoints = (int)enemyForm[0] + (int)enemyForm[1] + (int)enemyForm[2] + (int)enemyForm[3];



        SortedDictionary<int, List<Vector3>> generalPositions = new SortedDictionary<int, List<Vector3>>();
        //List<Vector3> specificPositions = new List<Vector3>();
        Vector3 aux;


        for (int i = 0; i < 4; i++)
        {
            //specificPositions.Clear();
            List<Vector3> specificPositions = new List<Vector3>();
            if (enemyForm[i] == Type.TRIANGULO)
            {
                int auxDistX = Random.Range(tMX - 300, tMX + 300);
                int auxDistY = Random.Range(tMY - 600, tMY + 100);

                //generate triangle center
                Vector3 center = generateRandomPoint(new Vector2(-50,50),new Vector2(-390,-90));

                //generate triangle vertex 1(up)
                aux = new Vector3(0, auxDistX, 0);
                specificPositions.Add(center + aux);

                //generate triangle vertex 2(left)
                aux = new Vector3(-1*auxDistX, -(2 / 3) * auxDistY, 0);
                specificPositions.Add(center + aux);

                //generate triangle vertex 3(right)
                aux = new Vector3(auxDistX, -(2 / 3) * auxDistY, 0);
                specificPositions.Add(center + aux);


                //push it on the map
                generalPositions.Add(i, specificPositions);
                //clear aux stuff
                //specificPositions.Clear();
            }
            else if (enemyForm[i] == Type.CUADRADO)
            {
                int randomDistance = Random.Range(sM - 200, sM + 200);
                //generate vertex 1 (up left corner)
                aux = generateRandomPoint(new Vector2(-600, 300 - randomDistance), new Vector2(-1100 + randomDistance, 200 - randomDistance));//- and + random distance to kow it would fit on the screen
                specificPositions.Add(aux);

                //generate next 3 vertex
                specificPositions.Add(aux + new Vector3(randomDistance, 0, 0));  // up right corner
                specificPositions.Add(aux + new Vector3(0, -randomDistance, 0)); // down left corner
                specificPositions.Add(aux + new Vector3(randomDistance, -randomDistance, 0)); // down right corner

                //push it on the map
                generalPositions.Add(i, specificPositions);
                //clear aux stuff
                //specificPositions.Clear();

            }
            else if (enemyForm[i] == Type.PENTAGONO)
            {
                
            }
            else if (enemyForm[i] == Type.CIRCULO)
            {
                int randomRadius = Random.Range(radius - randomVariation, radius + randomVariation);

                //generate the 4 basic vertex (up, down, right, left)
                specificPositions.Add(new Vector3(randomRadius, 0, 0));
                specificPositions.Add(new Vector3(-randomRadius, 0, 0));
                specificPositions.Add(new Vector3(0, randomRadius, 0));
                specificPositions.Add(new Vector3(0, -randomRadius, 0));

                //generate the 4 45º vertex
                specificPositions.Add(new Vector3(randomRadius * Mathf.Sin(45), randomRadius * Mathf.Cos(45), 0));
                specificPositions.Add(new Vector3((randomRadius * Mathf.Sin(45))*(-1), randomRadius * Mathf.Cos(45), 0));
                specificPositions.Add(new Vector3(randomRadius * Mathf.Sin(45), (randomRadius * Mathf.Cos(45))*(-1), 0));
                specificPositions.Add(new Vector3((randomRadius * Mathf.Sin(45))*(-1), (randomRadius * Mathf.Cos(45))*(-1), 0));

                generalPositions.Add(i, specificPositions);
            }
            else
            {
                Debug.LogError("Falta poner el tipo de enemigo en startCapture.cs del enemigo");
            }

        }

        return generalPositions;
    }
}
