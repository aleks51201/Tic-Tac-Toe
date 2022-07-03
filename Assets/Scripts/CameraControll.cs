using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 DragOrigin, NewPosition;
    public int ZoomSpeed;
    private float NewSize;
    private int move_x, move_y;
    public int minZoom, maxZoom;

    private void Start()
    {
        move_x = GetComponent<FieldGenerator>().columns;
        move_y = GetComponent<FieldGenerator>().rows;
    }
    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            NewSize = Mathf.Clamp(cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed, minZoom, maxZoom);
            cam.orthographicSize = NewSize;
        }

        if (Input.GetMouseButtonDown(2))
        {
            DragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(2))
        {
            Vector3 difference = DragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            
            float newX = Mathf.Clamp(cam.transform.position.x + difference.x, 0, move_x);
            float newY = Mathf.Clamp(cam.transform.position.y + difference.y, 0, move_y);
            NewPosition = new Vector3(newX, newY,-10);
            cam.transform.position = NewPosition;
            
            
        }
    }
}

