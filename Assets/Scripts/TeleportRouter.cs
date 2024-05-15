using UnityEngine;

public class TeleportRouter : MonoBehaviour
{
    private bool InYellow;
    private bool InRed;
    private bool InBlue;
    private bool InSearch;
    private bool Exit;
    private bool InRedRoom;
    private bool ExitToLobby;
    public UniversalTeleporter universalTeleporter;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InYellow && !Count.over)
        {
            universalTeleporter.ToRedRoom();
            InYellow = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && InRed && !Count.over)
        {
            universalTeleporter.ToMaze();
            InRed = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && InBlue && Count.count != 0 && !Count.over)
        {
            universalTeleporter.ToSearchdRoom();
        }
        if (Input.GetKeyDown(KeyCode.E) && Exit)
        {
            universalTeleporter.toLobby();
            Debug.Log("dfgkjfkgjfg");
            InBlue = false;
            Exit = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && ExitToLobby)
        {
            universalTeleporter.toLobby();
            Debug.Log("dfgkjfkgjfg");
            ExitToLobby = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && InSearch &&  Count.count != 0)
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
        if (collision.CompareTag("Exit"))
        {
            Exit = true;
        }
        if (collision.CompareTag("ExitToLobby"))
        {
            ExitToLobby = true;
        }


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("YellowDoor"))
        {
            InYellow = false;
        }

        if (collision.CompareTag("RedDoor"))
        {
            InRed = false;
        }
        if (collision.CompareTag("BlueDoor"))
        {
            InBlue = false;
        }
        if (collision.CompareTag("Mayor"))
        {
            InSearch = false;
        }
        if (collision.CompareTag("Exit"))
        {
            Exit = false;
        }
        if (collision.CompareTag("ExitToLobby"))
        {
            ExitToLobby = false;
        }


    }

}