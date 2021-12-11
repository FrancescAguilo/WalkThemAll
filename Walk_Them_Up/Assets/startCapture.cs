﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class startCapture : MonoBehaviour
{
    public enum Type { TRIANGULO = 3, CUADRADO = 4, PENTAGONO = 5, CIRCULO = 6 };

    [SerializeField] GameObject capturePointsPF;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject myCanvas;
    public int tiempoEntreBolas = 1;
    public int numGenerated = 5;
    List<Vector3> positions = new List<Vector3>();
    public Type[] enemyForm;
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

    //geometry

    int tMX = 500; //triangleMagnitude on X 
    int tMY = 500; //triangleMagnitude on Y

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
        //caso estandar
        if (true)
        {
            //spawnear 5 con 1 seg de delay


            if (!empezada2)
            {

                //Debug.Log("2");
                StartCoroutine("generatorManager");

            }

        }

    }

    IEnumerator generatorManager()
    {
        empezada2 = true;
        int i = 0;
        while (i < 5)
        {
            if (!empezada)
            {
                Debug.Log("soy la rutina " + i);
                StartCoroutine("generateCapturePoints");
                yield return new WaitForSeconds(6);
                i++;
                //positions = generatePositions(numGenerated);
                pointsPositions = generateGeometricPositions();
            }
            Debug.Log("ahora espero a que " + i + " acabe");
        }
        //stopCorroutines();
    }


    IEnumerator generateCapturePoints()
    {
        

        for (int i = 0; i < 4; i++)
        {
            //Debug.Log("ahora empiezo: " + pointsPositions[i].Count);
            int aux = i;
            //GameObject newButton = Instantiate(capturePointsPF, positions[i], Quaternion.identity) as GameObject;
            //for (int j = 0; j < pointsPositions[i].Count; j++)
            for (int j = 0; j < 3; j++)
            {
                GameObject newButton = Instantiate(capturePointsPF, pointsPositions[i][j], Quaternion.identity) as GameObject;
                aux = i + 1 + j;
                newButton.GetComponentInChildren<Text>().text = aux.ToString();
                
                newButton.transform.SetParent(myCanvas.transform, false);

           
            }
            yield return new WaitForSeconds(10);
            //Debug.Log("Ahora Espero 10 secs");
        }

        empezada = true;
        fin = false;
        stopCorroutines();
    }

    

    public void stopCorroutines()
    {
        StopCoroutine("generateCapturePoints");
        fin = true;
        empezada = false;

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

    public Vector3 generateRandomCenter()
    {
        //return new Vector3(Random.Range(-250, 50), Random.Range(-390, 90), 0);
        return new Vector3(Random.Range(-50, 50), Random.Range(-390, -90), 0);

    }

    public SortedDictionary<int, List<Vector3>> generateGeometricPositions()
    {
        //int nPoints = (int)enemyForm[0] + (int)enemyForm[1] + (int)enemyForm[2] + (int)enemyForm[3];



        SortedDictionary<int, List<Vector3>> generalPositions = new SortedDictionary<int, List<Vector3>>();
        List<Vector3> specificPositions = new List<Vector3>();
        Vector3 aux;


        for (int i = 0; i < 4; i++)
        {
            if (enemyForm[i] == Type.TRIANGULO)
            {
                int auxDistX = Random.Range(tMX - 300, tMX + 300);
                int auxDistY = Random.Range(tMY - 600, tMY + 100);
                //generate triangle center
                Vector3 center = generateRandomCenter();

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
            }
            else if (enemyForm[i] == Type.CUADRADO)
            {
                for (int j = 0; j < (int)enemyForm[i]; j++)
                {

                }
            }
            else if (enemyForm[i] == Type.PENTAGONO)
            {
                for (int j = 0; j < (int)enemyForm[i]; j++)
                {

                }
            }
            else if (enemyForm[i] == Type.CIRCULO)
            {
                for (int j = 0; j < (int)enemyForm[i]; j++)
                {

                }
            }
            else
            {
                Debug.LogError("Falta poner el tipo de enemigo en startCapture.cs del enemigo");
            }

        }

        return generalPositions;
    }
}
