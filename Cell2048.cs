﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2048 : MonoBehaviour
{
    public Cell2048 right;
    public Cell2048 left;
    public Cell2048 up;
    public Cell2048 down;

    public Fill2048 fill;





    private void OnEnable()
    {
        p2048contr.slide += OnSlide;
    }
    private void OnDisable()
    {
        p2048contr.slide -= OnSlide;
    }


    private void OnSlide(string whatWasSent)
    {
        //controller for computer
        CellCheck();
        Debug.Log(whatWasSent);
        if (whatWasSent == "w")
        {
            if (up != null)
                return;
            Cell2048 currentCell = this;
            SlideUp(currentCell);
        }
        if (whatWasSent == "d")
        {

            if (right != null)
                return;
            Cell2048 currentCell = this;
            SlideRight(currentCell);
        }
        if (whatWasSent == "s")
        {

            if (down != null)
                return;
            Cell2048 currentCell = this;
            SlideDown(currentCell);
        }
        if (whatWasSent == "a")
        {

            if (left != null)
                return;
            Cell2048 currentCell = this;
            SlideLeft(currentCell);
        }

        p2048contr.ticker++;
        if(p2048contr.ticker == 4)
        {
            p2048contr.instance.SpawnFill();
        }

    }

    void SlideUp(Cell2048 currentCell)
    {

        Debug.Log(currentCell.gameObject);





        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.down; //check what number is down
            while (nextCell.down != null && nextCell.fill == null)// if is good number down
            {
                nextCell = nextCell.down; // down number go to up
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value) //check numbers are equal or not
                {
                    nextCell.fill.Double(); //add one number to another
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill; // change cells
                    nextCell.fill = null;
                }
                else if(currentCell.down.fill != nextCell.fill)
                {
                    Debug.Log("!Doubled");
                    nextCell.fill.transform.parent = currentCell.down.transform;
                    currentCell.down.fill = nextCell.fill;
                    nextCell.fill = null;

                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);
                Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.down == null)
            return;

    }







    void SlideRight(Cell2048 currentCell)
    {

        Debug.Log(currentCell.gameObject);

        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.left.fill != nextCell.fill)
                {
                    Debug.Log("!Doubled");
                    nextCell.fill.transform.parent = currentCell.left.transform;
                    currentCell.left.fill = nextCell.fill;
                    nextCell.fill = null;

                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideRight(currentCell);
                Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.left == null)
            return;

    }






    void SlideDown(Cell2048 currentCell)
    {

        Debug.Log(currentCell.gameObject);

        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.up.fill != nextCell.fill)
                {
                    Debug.Log("!Doubled");
                    nextCell.fill.transform.parent = currentCell.up.transform;
                    currentCell.up.fill = nextCell.fill;
                    nextCell.fill = null;

                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideDown(currentCell);
                Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.up == null)
            return;

    }







    void SlideLeft(Cell2048 currentCell)
    {

        Debug.Log(currentCell.gameObject);

        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.right.fill != nextCell.fill)
                {
                    Debug.Log("!Doubled");
                    nextCell.fill.transform.parent = currentCell.right.transform;
                    currentCell.right.fill = nextCell.fill;
                    nextCell.fill = null;

                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideLeft(currentCell);
                Debug.Log("Slide to Empty");
            }
        }

        if (currentCell.right == null)
            return;

    }
    void CellCheck() // check are there place to generate new number or not, check where user can go(up,down,right,left)
    {
        if (fill == null)
            return;
        if(up != null)
        {
            if (up.fill == null)
                return;
            if (up.fill.value == fill.value)
                return;
        }
        if (down!= null)
        {
            if (down.fill == null)
                return;
            if (down.fill.value == fill.value)
                return;
        }
        if (right != null)
        {
            if (right.fill == null)
                return;
            if (right.fill.value == fill.value)
                return;
        }
        if (left != null)
        {
            if (left.fill == null)
                return;
            if (left.fill.value == fill.value)
                return;
        }
        //p2048contr.instance.gameOverCheck();

    }
}

