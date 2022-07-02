using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCamera : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        int move_x = GetComponent<FieldGenerator>().columns;
        int move_y = GetComponent<FieldGenerator>().rows;
        transform.position = new Vector3(move_x/2, move_y/2, -10);
    }

}
