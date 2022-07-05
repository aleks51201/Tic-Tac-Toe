using UnityEngine;


public class camera : MonoBehaviour
{
    public Camera cam;
    public static int width;

    // Start is called before the first frame update
    void Start()
    {
        GameField width = new GameField();
        GameField height = new GameField();
        float x = width.width;
        float y = height.height;
        cam.orthographicSize = 3;
        cam.transform.position = new Vector3(x / 2, y / 2,-1);
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
