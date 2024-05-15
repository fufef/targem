using UnityEngine;
using System;
using TMPro;

public class RandomMessageOnTriggerEnter : MonoBehaviour
{
    public string message;
    public TextMeshProUGUI dialogueText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // ���������� ��������� ����� �� -5 �� +5
            int randomNumber = UnityEngine.Random.Range(-5, 6);

            // ��������� ��������� � �������������� ���������� �����
            string formattedMessage = string.Format(message, randomNumber);

            // ������� ��������� � ���������� ����
            dialogueText.text = formattedMessage;
        }
    }
}
