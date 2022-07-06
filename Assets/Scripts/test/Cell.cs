using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Cell : MonoBehaviour
{
    private Dictionary<Type, ICellState> statesMap;
    private ICellState stateCurrent;

    private void Start()
    {
        this.InitStates();
        this.SetStateByDefault();
    }

    private void InitStates()
    {
        statesMap = new Dictionary<Type, ICellState>();

        this.statesMap[typeof(CellStateEmpty)] = new CellStateEmpty();
        this.statesMap[typeof(CellStateCross)] = new CellStateCross();
        this.statesMap[typeof(CellStateZero)] = new CellStateZero();
    }

    private void SetState(ICellState newState)
    {
        if(this.stateCurrent != null)
        {
            this.stateCurrent.Exit();
        }
        this.stateCurrent = newState;
        this.stateCurrent.Enter();
    }

    private void SetStateByDefault()
    {
        this.SetStateEmpty();
    }

    private ICellState GetState<T>() where T : ICellState
    {
        var type = typeof(T);
        return this.statesMap[type];
    }

    private void Update()
    {
        if (this.stateCurrent != null)
        {
            this.stateCurrent.Update();
        }
    }

    public void SetStateEmpty()
    {
        var state = this.GetState<CellStateEmpty>();
        this.SetState(state);
    }
    public void SetStateCross()
    {
        var state = this.GetState<CellStateCross>();
        this.SetState(state);
    }
    public void SetStateZero()
    {
        var state = this.GetState<CellStateZero>();
        this.SetState(state);
    }



}
