using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class FieldGenerator : MonoBehaviour
{

    public int rows;
    public int columns;

    public GameObject Tile;
    private Transform Field;



    void GenerateField()
    {
        columns = DataHolder.FieldSize;
        rows = DataHolder.FieldSize;
        Field = new GameObject("Field").transform;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject instance = Instantiate(Tile, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(Field);
            }
        }
    }
    public void SetupScene()
    {
        GenerateField();
    }
    void Start()
    {
        SetupScene();
    }

}
