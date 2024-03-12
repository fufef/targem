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
        DrawRectangle(-size, size, -size, size);
        for (int x = size + 1; x < size + 10; x++)
        {
            var pixels = Random.Range(0, 5);
            for (int i = 0; i < pixels; i++)
            {
                MakeWall(dirt, x, Random.Range(-size, size));
            }
        }

        for (int x = -(size + 1); x > -(size + 10); x--)
        {
            var pixels = Random.Range(0, 5);
            for (int i = 0; i < pixels; i++)
            {
                MakeWall(dirt, x, Random.Range(-size, size));
            }
        }
    }

    void DrawRectangle(int x1, int x2, int y1, int y2)
    {
        for (int x = x1; x <= x2; x++)
        {
            MakeWall(dirt, x, y1);
        }

        for (int x = x1; x <= x2; x++)
        {
            MakeWall(dirt, x, y2);
        }

        for (int y = y1; y <= y2; y++)
        {
            MakeWall(dirt, x1, y);
        }

        for (int y = y1; y <= y2; y++)
        {
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
    }
}
