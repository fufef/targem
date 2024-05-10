using UnityEngine;

public class TeleportRouter : MonoBehaviour
{
    private bool InYellow;
    private bool InRed;
    private bool InBlue;
    private bool InSearch;   
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

        if (Input.GetKeyDown(KeyCode.E) && InBlue)
        {
            universalTeleporter.ToSearchdRoom();
            InBlue = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && InSearch)
        {
            universalTeleporter.toSearch();
            InSearch = false;
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
        if (collision.CompareTag("BlueDoor"))
        {
            InBlue = true;
        }
        if (collision.CompareTag("Mayor"))
        {
            InSearch = true;
        }
    }

}