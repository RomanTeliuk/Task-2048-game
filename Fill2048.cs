using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill2048 : MonoBehaviour
{
    public int value;
    [SerializeField] Text valueDisplay;
    bool hasCombine;

    public float speed;



    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        valueDisplay.text = value.ToString(); // to change numbers on fills
    }
    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            hasCombine = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime); //also controller ,sped ,toward
        }
        else if (hasCombine == false)
        {
            if (transform.parent.GetChild(0) != this.transform) //check were some changing numbers or not
            {
                Destroy(transform.parent.GetChild(0).gameObject); // if numbers matches destroy one element(number)
            }
            hasCombine = true;
        }
    }
    public void Double() // add numbers like in 2048
    {
        value *= 2;

        valueDisplay.text = value.ToString(); // change number on fill;
    }

}