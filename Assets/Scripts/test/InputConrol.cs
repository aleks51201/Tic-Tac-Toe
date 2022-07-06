using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputConrol : MonoBehaviour
{
    public GameObject gfield;

    private IField fieldConrolObject;

    private void Start()
    {
        fieldConrolObject = gfield.GetComponent<IField>();

        if (fieldConrolObject == null)
            throw new NullReferenceException("gfild does not have IFild interface") ;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            fieldConrolObject.CreateField();
        }
    }
}
