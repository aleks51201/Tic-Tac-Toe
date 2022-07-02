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
    private List<Vector3> gridPositions = new List<Vector3>();


    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        //Clear our list gridPositions.
        gridPositions.Clear();

        //Loop through x axis (columns).
        for (int x = 1; x < columns; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 1; y < rows; y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }
    void GenerateField()
    {
        //Instantiate Board and set boardHolder to its transform.
        Field = new GameObject("Field").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < columns; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < rows; y++)
            {
                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance = Instantiate(Tile, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(Field);
            }
        }
    }
    public void SetupScene()
    {
        //Creates the outer walls and floor.
        GenerateField();

        //Reset our list of gridpositions.
        InitialiseList();




    }
    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
