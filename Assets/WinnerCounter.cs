using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCounter : MonoBehaviour
{
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
        Debug.Log("789");
        for (int i = 0; i < 8; i++)
        {
            Vector2 CheckCoordinates = TileCoordinates + Sides[i];
            bool Shout = CheckStep(TileTag, CheckCoordinates);
            Debug.Log(Shout);
        }
    }
    public bool CheckStep(string TileTag, Vector2 TileCoordinates) //check the tile on the given coordinates if it match the given Tag
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
}
