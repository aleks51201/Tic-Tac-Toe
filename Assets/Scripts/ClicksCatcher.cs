using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClicksCatcher : MonoBehaviour
{
    public Camera Cam;
    public GameObject GameManage;
    public TextMeshProUGUI InfoPanelTurn;
    public GameObject[] sprites = new GameObject[2];


    // Start is called before the first frame update
    void Start()
    {
        GameManage = GameObject.Find("GameManage");
    }

    void Update()
    {
        bool GameON = GameManage.GetComponent<GameManage>().IsGameOn(false, "");
        if (Input.GetMouseButtonDown(0) && GameON == true && !EventSystem.current.IsPointerOverGameObject(0))
        {
/*                private bool IsPointerOverUIObject()
            {
                PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
                return results.Count > 0;
            }*/
            RaycastHit2D Hit = new RaycastHit2D();
            Hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Hit.transform.tag == "Tile")
            {
                string Turn = GameManage.GetComponent<GameManage>().GetTurn();
                if (Turn == "zero")
                {
                    /*Hit.transform.GetComponent<SpriteRenderer>().sprite = sprites[0];*/
                    GameObject instance = Instantiate(sprites[0], new Vector3(Hit.transform.position.x, Hit.transform.position.y,-1), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(Hit.transform);
                    Hit.transform.tag = "TileZero";
                    Vector2 HitPos = Hit.transform.position;
                    /*Hit.transform.GetComponent<TileCheckUp>().check();*/
                    GameManage.GetComponent<WinnerCounter>().DoTheCount("TileZero", HitPos);
                    InfoPanelTurn.text = "Cross";
                }
                else
                {
                    /*Hit.transform.GetComponent<SpriteRenderer>().sprite = sprites[1];*/
                    GameObject instance = Instantiate(sprites[1], new Vector3(Hit.transform.position.x, Hit.transform.position.y, -1), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(Hit.transform);
                    Hit.transform.tag = "TileCross";
                    Vector2 HitPos = Hit.transform.position;
                    /*Hit.transform.GetComponent<TileCheckUp>().check();*/
                    GameManage.GetComponent<WinnerCounter>().DoTheCount("TileCross", HitPos);
                    InfoPanelTurn.text = "Zero";
                }
            } 
        }
    }
}





