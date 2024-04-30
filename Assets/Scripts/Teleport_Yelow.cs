using UnityEngine;

public class Teleport_Yelow : MonoBehaviour
{
    private bool IN;
    public UniversalTeleporter universalTeleporter;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IN)
        {
            universalTeleporter.ToRedRoom();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("YellowDoor"))
        {
            IN = true;
        }
    }

}