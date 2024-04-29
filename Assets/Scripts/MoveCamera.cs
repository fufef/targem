using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Camera; // Назначьте целевую позицию в инспекторе
    private bool IN;
    private void Update()
    {
        // Переместить камеру к целевой позиции
        if (IN)
        {
            Camera.position = new Vector3(-42.8f,34.1f,-10f) ;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spawn"))
        { 
            Debug.Log("1");
            IN = true;
           
        }
    }
}