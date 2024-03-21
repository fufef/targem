using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField] 
    private int height;

    [SerializeField]
    private Wall wall;

    [SerializeField]
    private int rooms;

    [SerializeField]
    private int size;

    [SerializeField]
    private int defaultSize;

    [SerializeField]
    private Sprite wallSprite;

    [SerializeField]
    private GameObject door;

    private List<Wall> walls = new List<Wall>();

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generation()
    {
        DrawRectangle(-5, 5, -4, 4);
        DrawHorizontal(-5, 5, 5);
        MakeDoor(door, -3, 4);
        MakeDoor(door, 0, 4);
        MakeDoor(door, 3, 4);
    }

    void DrawHorizontal(int x1, int x2, int y)
    {
        for (int x = x1; x <= x2; x++) 
        {
            MakeWall(wall, x, y);
        }
    }

    void DrawVertical(int x, int y1, int y2)
    {
        for (int y = y1; x <= y2; x++)
        {
            MakeWall(wall, x, y);
        }
    }

    void MakeDefaultRectangle(int x, int y, bool withHoles = false)
    {
        var x1 = x - defaultSize / 2;
        var x2 = x + defaultSize / 2;
        var y1 = y - defaultSize / 2;
        var y2 = y + defaultSize / 2;
        DrawRectangle(x1, x2, y1, y2, withHoles);
    }

    void DrawRectangle(int x1, int x2, int y1, int y2, bool withHoles = false)
    {
        for (int x = x1; x <= x2; x++)
        {
            if (withHoles)
            {
                if (x == ((x1 + x2) / 2))
                {
                    continue;
                }
            }

            MakeWall(wall, x, y1);
        }

        for (int x = x1; x <= x2; x++)
        {
            if (withHoles)
            {
                if (x == ((x1 + x2) / 2))
                {
                    continue;
                }
            }

            MakeWall(wall, x, y2);
        }

        for (int y = y1; y <= y2; y++)
        {
            if (withHoles)
            {
                if (y == ((y1 + y2) / 2))
                {
                    continue;
                }
            }

            MakeWall(wall, x1, y);
        }

        for (int y = y1; y <= y2; y++)
        {
            if (withHoles)
            {
                if (y == ((y1 + y2) / 2))
                {
                    continue;
                }
            }

            MakeWall(wall, x2, y);
        }
    }

    void MakeDoor(GameObject obj, int x, int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
        var collider = obj.gameObject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1.5f, 1.5f);
        collider.enabled = true;
        collider.isTrigger = true;
        obj.name = $"DOOR {x} {y}";
    }

    void MakeWall(Wall obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
        var rigid = obj.gameObject.AddComponent<Rigidbody2D>();
        var collider = obj.gameObject.AddComponent<BoxCollider2D>();
        collider.enabled = true;
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        rigid.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        obj.name = $"{width} {height}";
        obj.ChangeSprite(wallSprite);
        walls.Add(obj);
    }

    public void ChangeWalls(Sprite sprite)
    {
        foreach (var wall in walls)
        {
            wall.ChangeSprite(sprite);
        }
    }
}
