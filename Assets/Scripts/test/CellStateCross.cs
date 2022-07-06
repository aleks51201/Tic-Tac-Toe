using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStateCross : ICellState
{
    public void Enter()
    {
        Debug.Log("Enter Cross state");
    }

    public void Exit()
    {
        Debug.Log("Exit Cross state");
    }

    public void Update()
    {
        Debug.Log("Update Cross state");
    }
}
