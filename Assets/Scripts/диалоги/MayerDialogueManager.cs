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
    private int count = 0;
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
        if (Input.GetKeyDown(KeyCode.F) && playerInCollider)
        {
            StartDialogue(new string[] {
        "����: ��� �� ���",
        "����: �������� ���, ����� ������, ����� �������!",
        "���: � ������ �� ���� ��� ��������!",
        "���: �� ���� �� ��� ������ 12 ����� �� ������, �� �������� ������ ������",
        "����� F � ����� �����"
        });
          //  count++;
        }

        if (playerInCollider && count == 1)
        {
            StartDialogue(new string[] {
        "���: ��� ��������!",
        "���: �����, �� ���, � � �� �����",
        "����: ��� � ������"
        });
            count++;
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInCollider && count == 2)
        {
            StartDialogue(new string[] {
        "��� �������� �����!",
        "� ������� ������ �� �������"
        });
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextDialogueLine();
        }
    }
}
