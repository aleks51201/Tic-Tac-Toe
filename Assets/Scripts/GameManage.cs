using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManage : MonoBehaviour
{
    private string Turn = null;
    private bool GameON = true;
    public GameObject GameEndUI;
    public GameObject GameOnUI;
    public TextMeshProUGUI WinnerText;
    public TextMeshProUGUI InfoPanelTurn;


    public string GetFirstTurn()
    {
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            Turn = "zero";
            InfoPanelTurn.text = "Cross";
            return Turn;
        }
        else
        {
            Turn = "cross";
            InfoPanelTurn.text = "Zero";
            return Turn;
        }
    }
    public string ChangeTurn(string currentTurn)
    {
        if(currentTurn == "zero")
        {
            Turn = "cross";
            return Turn;
        }
        else if (currentTurn == "cross")
        {
            Turn = "zero";
            return Turn;
        }
        return null;
    }
    public string GetTurn()
    {
        if (Turn == null) {
            Turn = GetFirstTurn();
            return Turn;
        }
        else
        {
            Turn = ChangeTurn(Turn);
            return Turn;
        }
    }

        
        void Start()
    {
        GetTurn();
    }

    
    void Update()
    {
    }

    public bool IsGameOn(bool action, string Winner)
    {
        if (action == true)
        {
            GameON = false;
            Turn = null;
            ShowEndGameUI(Winner);
        }
        return GameON;
    }

    public void ShowEndGameUI(string Winner)
    {
        if(Winner == "TileCross")
        {
            WinnerText.text = "Cross Wins!";
        }
        else if(Winner == "TileZero")
        {
            WinnerText.text = "Zero Wins!";
        }
        else if (Winner == "Draw")
        {
            WinnerText.text = "That`s a Draw!";
        }
        GameEndUI.SetActive(true);
        GameOnUI.SetActive(false);
    }
}
