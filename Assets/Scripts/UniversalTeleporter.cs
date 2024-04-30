using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UniversalTeleporter : MonoBehaviour
{
    public Light2D player;
    public Transform Camera;
    public Transform Player;
    public Transform RedRoom;
    public Transform RedRoomCamera;
    public Transform Maze;
    public Transform MazeCamera;
    // Start is called before the first frame update
    public void ToRedRoom()
    {
        Teleport(RedRoom, RedRoomCamera);
    }

    public void ToMaze()
    {
        Teleport(Maze, MazeCamera);
        player.enabled = true;
    }

    public void Teleport(Transform target, Transform cameraTarget)
    {
        Camera.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, Camera.transform.position.z);
        Player.transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}
