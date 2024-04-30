using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalTeleporter : MonoBehaviour
{
    public Transform Camera;
    public Transform Player;
    public Transform RedRoom;
    public Transform RedRoomCamera;
    // Start is called before the first frame update
    public void ToRedRoom()
    {
        Teleport(RedRoom, RedRoomCamera);
    }

    public void Teleport(Transform target, Transform cameraTarget)
    {
        Camera.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, Camera.transform.position.z);
        Player.transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}
