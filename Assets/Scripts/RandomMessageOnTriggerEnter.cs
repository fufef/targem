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
            // √енерируем случайное число от -5 до +5
            int randomNumber = UnityEngine.Random.Range(-5, 6);

            // ‘ормируем сообщение с использованием случайного числа
            string formattedMessage = string.Format(message, randomNumber);

            // ¬ыводим сообщение в диалоговое окно
            dialogueText.text = formattedMessage;
        }
    }
}
