using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellState
{
    void Enter();
    void Exit();
    void Update();
}
