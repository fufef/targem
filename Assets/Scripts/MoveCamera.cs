using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Camera; // ��������� ������� ������� � ����������
    private bool IN;
    private void Update()
    {
        // ����������� ������ � ������� �������
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