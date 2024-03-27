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
    private SlimWall slimWall;

    [SerializeField]
    private int rooms;

    [SerializeField]
    private int size;

    [SerializeField]
    private int defaultSize;

    [SerializeField]
    private Sprite wallSprite;

    [SerializeField] 
    private Sprite slimWallSprite;

    [SerializeField]
    private GameObject door;

    private List<Wall> walls = new List<Wall>();

    private MazeGen mazeGen = new MazeGen();

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    public void GenerateMaze()
    {
        var maze = mazeGen.GetMaze(21, 1, 1);
        for (int x = 0; x < 21; x++)
        {
            for (int y = 0; y < 21; y++)
            {
                if (!maze[x, y])
                {
                    MakeWall(wall, x + 40, y + 40);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generation()
    {
        DrawRectangle(-12, 12, -5, 0);
      //  DrawHorizontal(-5, 5, 5);
        MakeDoor(door, -8, 0.5f);
        MakeDoor(door, 0, 0.5f);
        MakeDoor(door, 8, 0.5f);
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

    void MakeDoor(GameObject obj, float x, float y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
        var collider = obj.gameObject.AddComponent<BoxCollider2D>();
        collider.tag = $"YellowDoor";
        collider.size = new Vector2(2.5f, 3f);
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

    public enum DirectionW
    {
        WallFront,
        WallLeft,
        WallRight,
        WallBack
    }

    void MakeSlimWall(SlimWall wall, int x, int y, DirectionW direction)
    {
        if (direction == DirectionW.WallFront)
        {
            MakeSlimWallInternal(wall, x, y + 0.5f, false);
        }

        if (direction == DirectionW.WallLeft)
        {
            MakeSlimWallInternal(wall, x - 0.5f, y, true);
        }
        
        if (direction == DirectionW.WallRight)
        {
            MakeSlimWallInternal(wall, x + 0.5f, y, true);
        }

        if (direction == DirectionW.WallBack)
        {
            MakeSlimWallInternal(wall, x, y - 0.5f, false);
        }
    }

    void MakeSlimWallInternal(SlimWall obj, float width, float height, bool isVertical)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.localScale = new Vector2(isVertical ? 0.1f : 1.5f, isVertical ? 1.5f : 0.1f);
        obj.transform.parent = this.transform;
        var rigid = obj.gameObject.AddComponent<Rigidbody2D>();
        var collider = obj.gameObject.AddComponent<BoxCollider2D>();
        collider.enabled = true;
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        rigid.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        obj.name = $"{width} {height}";
    }

    void MakeSlimWallInternal(SlimWall obj, float x, float y, float w, float h)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.localScale = new Vector2(w, h);
        obj.transform.parent = this.transform;
        var rigid = obj.gameObject.AddComponent<Rigidbody2D>();
        var collider = obj.gameObject.AddComponent<BoxCollider2D>();
        collider.enabled = true;
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        rigid.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        obj.name = $"{x} {y}";
    }

    public void ChangeWalls(Sprite sprite)
    {
        foreach (var wall in walls)
        {
            wall.ChangeSprite(sprite);
        }
    }
}