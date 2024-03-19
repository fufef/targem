using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField] 
    private int height;

    [SerializeField]
    private GameObject dirt;

    [SerializeField]
    private int rooms;

    [SerializeField]
    private int size;

    [SerializeField]
    private int defaultSize;

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
        for (int x = -3; x <= 3;  x++)
        {
            for (int y = -3; y <= 3; y++)
            {
                MakeDefaultRectangle(x * defaultSize, y * defaultSize, true);
            }
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

            MakeWall(dirt, x, y1);
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

            MakeWall(dirt, x, y2);
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

            MakeWall(dirt, x1, y);
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

            MakeWall(dirt, x2, y);
        }
    }

    void MakeWall(GameObject obj, int width, int height)
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
        var rigid = obj.AddComponent<Rigidbody2D>();
        var collider = obj.AddComponent<BoxCollider2D>();
        collider.enabled = true;
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        rigid.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        obj.name = $"{width} {height}";
    }
}
