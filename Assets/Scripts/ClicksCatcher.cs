using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClicksCatcher : MonoBehaviour
{
    public Camera Cam;
    public GameObject GameManage;


    // Start is called before the first frame update
    void Start()
    {
        GameManage = GameObject.Find("GameManage");
    }

    void Update()
    {
        bool GameON = GameManage.GetComponent<GameManage>().IsGameOn(false);
        if (Input.GetMouseButtonDown(0) && GameON == true)
        {
            RaycastHit2D Hit = new RaycastHit2D();
            Hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Hit.transform.tag == "Tile")
            {
                string Turn = GameManage.GetComponent<GameManage>().GetTurn();
                if (Turn == "zero")
                {
                    Hit.transform.GetComponent<SpriteRenderer>().color = Color.blue;
                    Hit.transform.tag = "TileZero";
                    Vector2 HitPos = Hit.transform.position;
                    /*Hit.transform.GetComponent<TileCheckUp>().check();*/
                    GameManage.GetComponent<WinnerCounter>().DoTheCount("TileZero", HitPos);
                }
                else
                {
                    Hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
                    Hit.transform.tag = "TileCross";
                    Vector2 HitPos = Hit.transform.position;
                    /*Hit.transform.GetComponent<TileCheckUp>().check();*/
                    GameManage.GetComponent<WinnerCounter>().DoTheCount("TileCross", HitPos);
                }
            } 
        }
    }
}





