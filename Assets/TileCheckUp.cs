using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheckUp : MonoBehaviour
{

    Vector2 CurrPos;
    List<RaycastHit2D> Info;
    private Vector2 GetPos() {
        Vector2 CurrPos = new Vector2(transform.position.x - 0.5f, transform.position.y);
        return CurrPos;
    }
    public void check()
    {
        RaycastHit2D Hit;
        Hit = Physics2D.Raycast(CurrPos, Vector2.left,Mathf.Infinity, 1,-Mathf.Infinity,Mathf.Infinity);
        Info.Add(Hit);
        /*bool prout = Hit.transform.CompareTag("Tile");*/
        /*Debug.Log(prout);*/
    }

    private void Start()
    {
        CurrPos = GetPos();
    }
    private void FixedUpdate()
    {
        
        Debug.DrawRay(transform.position, Vector2.left, Color.red,1,true);
    }

}
