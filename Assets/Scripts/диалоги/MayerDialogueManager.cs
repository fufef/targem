using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MayerDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    private int currentLineIndex = 0;
    private string[] dialogueLines;
    private bool playerInCollider = false;
    private bool poisk = false;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(string[] dialogueLines)
    {
        this.dialogueLines = dialogueLines;
        currentLineIndex = 0;
        ShowNextDialogueLine();
        dialogueBox.SetActive(true);
    }

    public void ShowNextDialogueLine()
    {
        if (currentLineIndex < dialogueLines.Length && playerInCollider)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInCollider = false;
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider && Count.count == 12)
        {
            StartDialogue(new string[] {
        "Вейд: Вот вы где",
        "Вейд: Господин мэр, здесь опасно, нужно уходить!",
        "Мер: Я никуда не уйду без сокровищ!",
        "Мер: Но если ты мне найдёшь 12 вещей из списка, то последую твоему совету",
        "Нажми F и начни поиск"
        });
        }

        if (playerInCollider && Input.GetKeyDown(KeyCode.E) && Count.count == 0 && !poisk)
        {
            StartDialogue(new string[] {
        "Мер: Моя прелесть!",
        "Мер: Ладно, ты иди, а я за тобой",
        "Вейд: Вот и славно"
        });
            poisk = true;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogueLine();
        }
    }
}
