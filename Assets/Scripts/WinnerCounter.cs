using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerCounter : MonoBehaviour
{
    private int PassedTurns = 0;

    public GameObject GameManage, ExtraModInfoPanel;
    public TextMeshProUGUI InfoPanel;
    private int WinCount,TilesCount,CrossTilesCounter, ZeroTilesCounter = 0;
    private string Gamemode1;
    public int WinDueTiles = 25;
    private Color NewRed = new Color(255f / 255.0f, 131f / 255.0f, 131f / 255.0f);
    private Color NewBlue = new Color(131f / 255.0f, 131f / 255.0f, 255f / 255.0f);
    private void Awake()
    {
        Gamemode1 = DataHolder.Gamemode;
        if(Gamemode1 != "classic")
        {
            ExtraModInfoPanel.SetActive(true);
        }
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
        if (Gamemode1 != "classic")
        {
            CheckStepColor(TileTag, TileCoordinates);
        }
        
        for (int i = 0; i < 8; i++)
        {
            Vector2 CheckCoordinates = TileCoordinates + Sides[i];
            bool Shout = CheckStep(TileTag, CheckCoordinates);
            if (Gamemode1 != "classic")
            {
                CheckStepColor(TileTag, CheckCoordinates);
            }
            if (Shout == true)
            {
                 steps = CheckChein(TileTag, CheckCoordinates, Sides[i]);
                if (steps >= WinCount)
                {
                    GameManage.GetComponent<GameManage>().IsGameOn(true, TileTag);
                }
            }
        }


        if (Gamemode1 != "classic")
        {
            if (ZeroTilesCounter - CrossTilesCounter > 0)
            {
                InfoPanel.text = $"Zero: +{ZeroTilesCounter - CrossTilesCounter} (25)";
                InfoPanel.color = Color.blue;
            }
            else if (ZeroTilesCounter - CrossTilesCounter < 0)
            {
                InfoPanel.text = $"Cross: +{CrossTilesCounter - ZeroTilesCounter} (25)";
                InfoPanel.color = Color.red;
            }
            else
            {
                InfoPanel.text = "Draw";
                InfoPanel.color = Color.black;
            }

            if ((ZeroTilesCounter - WinDueTiles) >= CrossTilesCounter || (CrossTilesCounter - WinDueTiles) >= ZeroTilesCounter)
            {
                GameManage.GetComponent<GameManage>().IsGameOn(true, TileTag);
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
    public void CheckStepColor(string TileTag, Vector2 TileCoordinates)
    {
        try
        {
            RaycastHit2D Hit = new RaycastHit2D();
            Hit = Physics2D.Raycast(TileCoordinates, Vector2.zero);
            Color ColorHit = Hit.transform.GetComponent<SpriteRenderer>().color;
            if (Hit.transform.tag == "Tile")
            {

                if (TileTag == "TileCross")
                {
                    if (ColorHit == Color.white)
                    {
                        Hit.transform.GetComponent<SpriteRenderer>().color = NewRed;
                        CrossTilesCounter += 1;
                    }
                    if (ColorHit == NewBlue)
                    {
                        Hit.transform.GetComponent<SpriteRenderer>().color = Color.white;
                        ZeroTilesCounter -= 1;
                    }
                }
                if (TileTag == "TileZero")
                {
                    if (ColorHit == Color.white)
                    {
                        Hit.transform.GetComponent<SpriteRenderer>().color = NewBlue;
                        ZeroTilesCounter += 1;
                    }
                    if (ColorHit == NewRed)
                    {
                        Hit.transform.GetComponent<SpriteRenderer>().color = Color.white;
                        CrossTilesCounter -= 1;
                    }
                }
            }
            else if (TileTag == "TileCross" || TileTag == "TileZero")
            {
                Hit.transform.GetComponent<SpriteRenderer>().color = Color.white;
                if (TileTag == "TileCross" && ColorHit == NewBlue)
                {
                    ZeroTilesCounter -= 1;
                }
                else if (ColorHit == NewRed)
                {
                    CrossTilesCounter -= 1;
                }
            }
        }
        catch{}


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
