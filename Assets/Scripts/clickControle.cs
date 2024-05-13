using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickControle : MonoBehaviour
{
    public static string objectName;
    public GameObject objectNemeText;
    public UniversalTeleporter universalTeleporter = new UniversalTeleporter();
    

    private void OnMouseDown()
    {
        
        Debug.Log("нажат");

        if (objectNemeText != null)
        {
            Debug.Log(Count.count);
            Count.count--;
            Debug.Log(Count.count);
            objectName = gameObject.name;
            Debug.Log(objectName);
            Destroy(gameObject);
            Destroy(objectNemeText);
            objectNemeText = null;
            if (Count.count == 0) {
                Debug.Log(Count.count);
                Debug.Log("teleport");
                universalTeleporter.ToSearchdRoom(); }
        }
    }
}
