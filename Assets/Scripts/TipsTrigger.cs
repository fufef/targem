using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    public RectTransform objectToTeleport;
    public RectTransform newPosition;

    [TextArea(3,10)]
    [SerializeField] private string message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          //  RectTransform rectTransform = objectToTeleport.GetComponent<RectTransform>();
           // Debug.Log(rectTransform.position);
            //        rectTransform.anchoredPosition = newPosition.anchoredPosition;
            objectToTeleport.position = newPosition.position;

            TipsManager.displayTipEvent?.Invoke(message);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TipsManager.disabeTipEvent?.Invoke();
        }
    }

}
