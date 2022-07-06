using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStateEmpty : ICellState
{
    public void Enter()
    {
        Debug.Log("Enter Empty state");
    }

    public void Exit()
    {
        Debug.Log("Enter Empty state");
    }
    void ICellState.Update()
    {
        Debug.Log("Update Empty state");
    }
}
