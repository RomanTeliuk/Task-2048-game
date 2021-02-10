using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class p2048contr : MonoBehaviour
{





    public GameObject fillPrefab;
    public Cell2048[] allCells;
    public static Action<string> slide;
    public static p2048contr instance;
    public static int ticker;




    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartSpawnFill(); //start from 2 numbers
        StartSpawnFill();
    }


    void Update()
    {

        //controller

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ticker = 0;

            SpawnFill();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ticker = 0;

            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ticker = 0;

            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ticker = 0;

            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ticker = 0;

            slide("a");
        }
    }
    public void SpawnFill()
    {
        bool IsPlace = true;
        for(int i=0; i < allCells.Length; i++)
        {
           if(allCells[i].fill == null)
            {
                IsPlace = false;
            }
        }
        if(IsPlace == true)
        {
            return;
        }
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if(allCells[whichSpawn].transform.childCount !=0)
        {
            Debug.Log(allCells[whichSpawn].name + " filled");
            SpawnFill();
            return;
        }
        //random place for start numbers 2 or 4
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance < .2f)
        {
            return;
        }
        else if (chance < .8f)
        {

            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Debug.Log(2);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);


        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Debug.Log(4);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
    }



    public void StartSpawnFill()
    {
        //also for spawn numbers
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            Debug.Log(allCells[whichSpawn].name + "  filled");
            SpawnFill();
            return;
        }


            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Debug.Log(2);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);




    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
