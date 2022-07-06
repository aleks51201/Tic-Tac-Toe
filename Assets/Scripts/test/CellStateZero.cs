using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStateZero : ICellState
{
    public void Enter()
    {
        Debug.Log("Enter Zero state");
    }

    public void Exit()
    {
        Debug.Log("Enter Zero state");
    }

    void ICellState.Update()
    {
        Debug.Log("Update Zero state");
    }
}
