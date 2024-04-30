using UnityEngine;

public class TeleportRouter : MonoBehaviour
{
    private bool InYellow;
    private bool InRed;
    public UniversalTeleporter universalTeleporter;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InYellow)
        {
            universalTeleporter.ToRedRoom();
            InYellow = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && InRed)
        {
            universalTeleporter.ToMaze();
            InRed = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("YellowDoor"))
        {
            InYellow = true;
        }

        if (collision.CompareTag("RedDoor"))
        {
            InRed = true;
        }
    }

}