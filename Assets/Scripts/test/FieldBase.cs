using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class FieldBase : MonoBehaviour,IField
{
    public void Create()
    {
        Debug.Log("create field") ;
    }

    public void CreateField()
    {
        Create();
    }
}
