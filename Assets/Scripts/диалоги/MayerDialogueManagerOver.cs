using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MayerDialogueManagerOver : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextYellow;
    public GameObject dialogueBoxYellow;

    private int currentLineIndexYellow = 0;
    private string[] dialogueLinesYellow;
    private bool playerInColliderYellow = false;
    void Start()
    {
        dialogueBoxYellow.SetActive(false);
    }

    public void StartDialogueYellow(string[] dialogueLinesYellow)
    {
        this.dialogueLinesYellow = dialogueLinesYellow;
        currentLineIndexYellow = 0;
        ShowNextDialogueLineYellow();
        dialogueBoxYellow.SetActive(true);
    }

    public void ShowNextDialogueLineYellow()
    {
        if (currentLineIndexYellow < dialogueLinesYellow.Length)
        {
            dialogueTextYellow.text = dialogueLinesYellow[currentLineIndexYellow];
            currentLineIndexYellow++;
        }
        else
        {
            EndDialogueYellow();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInColliderYellow = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInColliderYellow = false;
            EndDialogueYellow();
        }
    }



    public void EndDialogueYellow()
    {
        dialogueBoxYellow.SetActive(false);
    }

    void Update()
    {



        if (Input.GetKeyDown(KeyCode.E) && playerInColliderYellow && Count.count == 0)
        {
            StartDialogueYellow(new string[] {
        "Вейд : Там случился обвал!",
        "Вейд : Мер вышел вовремя",
        "Вейд : В комнату больше не попасть"
        });
        }


        if (Input.GetKeyDown(KeyCode.Space) && playerInColliderYellow)
        {
            ShowNextDialogueLineYellow();
        }
    }
}
