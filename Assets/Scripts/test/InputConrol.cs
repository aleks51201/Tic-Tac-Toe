using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputConrol : MonoBehaviour
{
    public GameObject gfield;

    private Cell fieldConrolObject;

    private void Start()
    {
        fieldConrolObject = gfield.GetComponent<Cell>();

        if (fieldConrolObject == null)
            throw new NullReferenceException("gfild does not have ICellState interface") ;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.fieldConrolObject.SetStateZero();
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.fieldConrolObject.SetStateEmpty();
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.fieldConrolObject.SetStateCross();
        }
    }
}
