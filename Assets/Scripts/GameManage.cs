using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManage : MonoBehaviour
{
    private string Turn = null;
    private bool GameON = true;
    public string GetFirstTurn()
    {
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
        {
            string Turn = "zero";
            return Turn;
        }
        else
        {
            string Turn = "cross";
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

        // Start is called before the first frame update
        void Start()
    {
        GetTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGameOn(bool action)
    {
        if (action == true)
        {
            GameON = false;
            SceneManager.LoadScene("GameScene");
        }
        return GameON;
    }
}
