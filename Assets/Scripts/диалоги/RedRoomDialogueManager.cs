using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedRoomDialougeManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    private int currentLineIndex = 0;
    private string[] dialogueLines;
    private bool playerInCollider = false;
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
        if (currentLineIndex < dialogueLines.Length)
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
        }
    }



    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInCollider)
        {
            StartDialogue(new string[] {
        "Вейд: Чёрт возьми! Ты ещё кто такой?",
        "Вейд: Защищайся!",
        "Демон: К чему все эти крики? Я просто азартный игрок.",
        "Демон: Положи свой меч и оставь браваду. Присаживайся за стол, сыграем в кости.",
        "Вейд: Вот так просто? В чём подвох — играем на душу?",
        "Демон: Выиграешь — получишь что-то, что поможет в твоих поисках.",
        "Демон: Проиграешь — усложнишь себе поиски.",
        "Демон: Это все правила."
        });
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogueLine();
        }
    }
}
