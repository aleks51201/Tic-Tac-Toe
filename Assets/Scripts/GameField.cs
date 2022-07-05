using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{

    public GameObject block;

    public Camera cam;

    public int width = 10;
    public int height = 4;
    public int winning_combination = 3;

    private sbyte _toggle = 1;

    // Start is called before the first frame update
    void Start()
    {
        FieldCreate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Mouse();
        }
    }

    RaycastHit2D Mouse()
    {
        RaycastHit2D target;

        Vector2 mouse_position = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 beam_direction = Vector2.zero;

        target = Physics2D.Raycast(mouse_position, beam_direction);

        ChangeColor(target);
        WinCheck(target);

        return target;
    }

    void FieldCreate()
    {
        Transform field;

        _toggle = 1;

        field = GameObject.Find("GameManager").transform;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 vec = new Vector2(i, j);
                GameObject cell = Instantiate(block, vec, Quaternion.identity);
                cell.transform.SetParent(field);
                cell.tag = "Tile";
            }
        }
    }

    void ChangeColor(RaycastHit2D target)
    {
        Transform figure = target.transform;

        if (figure.tag != "TileCross" && figure.tag == "Tile" && _toggle == 1)
        {
            CellProcessing(figure, Color.red, "TileCross");
        }
        else if (figure.tag != "TileZero" && figure.tag == "Tile" && _toggle == -1)
        {
            CellProcessing(figure, Color.blue, "TileZero");
        }
    }

    void CellProcessing(Transform cell, Color hue, string tag)
    {
        var toggle = new Dictionary<sbyte, sbyte>()
        {
            { 1,-1},
            { -1, 1}
        };
        cell.GetComponent<SpriteRenderer>().color = hue;
        cell.tag = tag;
        _toggle = toggle[_toggle];

    }
    void WinCheck(RaycastHit2D first_object)
    {
        if (CheckAdjacentCells(first_object))
            _toggle = 0;
    }

    bool CheckAdjacentCells(RaycastHit2D starting_object)
    {
        RaycastHit2D expected_object;

        Vector2 beam_position;
        Vector2 starting_position = starting_object.transform.position;
        Vector2 position_shift;

        int x;
        int y;

        int[,] offset_direction =
        {
           {0, 1}, {1, 0}, {-1, 0}, {0, -1}, {1,1}, {-1,-1}, {-1,1},{1,-1}
        };

        sbyte num_sides = 8;

        for (sbyte i = 0; i < num_sides; i++)
        {
            x = offset_direction[i, 0];
            y = offset_direction[i, 1];
            position_shift = new Vector2(x, y);
            beam_position = starting_position + position_shift;

            expected_object = BeamCreate(beam_position);

            if (TagMatchingCheck(starting_object, expected_object))
            {
                return (ChainLenght(expected_object, position_shift) == winning_combination);
            }
        }
        return false;
    }

    RaycastHit2D BeamCreate(Vector2 beam_position)
    {
        RaycastHit2D expected_object;
        Vector2 beam_direction;

        beam_direction = Vector2.zero;

        expected_object = Physics2D.Raycast(beam_position, beam_direction);
        return expected_object;
    }

    bool TagMatchingCheck(RaycastHit2D first_object, RaycastHit2D second_object)
    {
        string first_object_tag = first_object.transform.tag;
        string second_object_tag;
        try
        {
            second_object_tag = second_object.transform.tag;
        }
        catch
        {
            return false;
        }
        return first_object_tag == second_object_tag;
    }

    int ChainLenght(RaycastHit2D start_object, Vector2 direction)
    {
        int forward = ChainMovement(start_object, direction);
        int back = ChainMovement(start_object, direction * -1);
        int sum = forward + back + 1;

        return sum;
    }

    int ChainMovement(RaycastHit2D start_object, Vector2 direction)
    {
        Vector2 start_position = start_object.transform.position;
        int num_links = 0;

        for (int i = 0; i < winning_combination; i++)
        {
            start_position += direction;
            if (TagMatchingCheck(start_object, BeamCreate(start_position)))
                num_links++;
        }
        return num_links;
    }
}
