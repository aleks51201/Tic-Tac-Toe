using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCounter : MonoBehaviour
{
    private int PassedTurns = 0;

    public GameObject GameManage;
    private int WinCount,TilesCount = 0;
    private void Awake()
    {
        if (DataHolder.FieldSize == 100)
        {
            WinCount = 5;
            TilesCount = DataHolder.FieldSize * DataHolder.FieldSize;
        }
        else
        {
            WinCount = 3;
            TilesCount = DataHolder.FieldSize * DataHolder.FieldSize;
        }

    }
    Vector2[] Sides = new[] { 
            new Vector2(-1, 0), 
            new Vector2(-1, 1), 
            new Vector2(0, 1), 
            new Vector2(1, 1), 
            new Vector2(1, 0), 
            new Vector2(1, -1), 
            new Vector2(0, -1), 
            new Vector2(-1, -1) };
    public void DoTheCount(string TileTag, Vector2 TileCoordinates)
    {
        int steps;
        PassedTurns += 1;
        for (int i = 0; i < 8; i++)
        {
            Vector2 CheckCoordinates = TileCoordinates + Sides[i];
            bool Shout = CheckStep(TileTag, CheckCoordinates);
            if (Shout == true)
            {
                 steps = CheckChein(TileTag, CheckCoordinates, Sides[i]);
                if (steps >= WinCount)
                {
                    GameManage.GetComponent<GameManage>().IsGameOn(true, TileTag);
                }
                Debug.Log(steps);
            }
            

        }
        bool GameON = GameManage.GetComponent<GameManage>().IsGameOn(false, "");
        if (PassedTurns >= TilesCount && GameON == true)
        {
            GameManage.GetComponent<GameManage>().IsGameOn(true, "Draw");
        }

    }
    public bool CheckStep(string TileTag, Vector2 TileCoordinates) //check the tile on the given coordinates if it match the given Tag
    {
        try
        {
            RaycastHit2D Hit = new RaycastHit2D();
            Hit = Physics2D.Raycast(TileCoordinates, Vector2.zero);
            if (Hit.transform.tag == TileTag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
        

    }
    public int CheckChein(string TileTag, Vector2 CheckStart, Vector2 Step)
    {
        
        int CurrentLenght = 2;
        bool TileMatch;
        Vector2 CurrentStep = CheckStart + Step;
        for (int i = 0; i < 3; i++) {
            TileMatch = CheckStep(TileTag, CurrentStep);
            if (TileMatch == true)
            {
                CurrentLenght += 1;
                CurrentStep += Step;
            }
            else
            {
                int CurrentLenghtReverse = CheckCheinReverse(TileTag, CurrentStep, Step);
                CurrentLenght = CurrentLenghtReverse;
                return CurrentLenght;
            }

        }
        return CurrentLenght;

    }
    public int CheckCheinReverse(string TileTag, Vector2 CurrentStep, Vector2 Step)
    {
        int CurrentLenght = 0;
        bool TileMatch;
        CurrentStep -= Step;
        for (int i = 0; i < 4; i++)
        {
            TileMatch = CheckStep(TileTag, CurrentStep);
            if (TileMatch == true)
            {
                CurrentLenght += 1;
                CurrentStep -= Step;
            }
            else
            {
                return CurrentLenght;
            }
        }
        return CurrentLenght;
    }
}
