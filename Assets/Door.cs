using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] 
    private bool triggerActive = false;

    [SerializeField]
    private Sprite behindDoorColor;

    [SerializeField]
    private MapGen mapGen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.F))
        {
            SomeCoolAction();
        }
    }

    public void SomeCoolAction()
    {
        Debug.Log("IN!");
        mapGen.ChangeWalls(behindDoorColor);
    }
}
