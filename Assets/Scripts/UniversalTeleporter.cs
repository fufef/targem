using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UniversalTeleporter : MonoBehaviour
{
    public Light2D playerLight;
    public Player player;
    public CameraScript CameraScript;
    public Transform Camera;
    public Transform Player;
    public Transform RedRoom;
    public Transform RedRoomCamera;
    public Transform Maze;
    public Transform MazeCamera;
    public Transform SearchRoom;
    public Transform SearchRoomCamera;
    public Transform Search;
    public Transform SearchCamera;
    public Transform Lobby;
    public Transform LobbyCamera;
    public Transform InRedRoom;
    // Start is called before the first frame update
    public void ToRedRoom()
    {
        Teleport(RedRoom, RedRoomCamera);
    }
    public void ToSearchdRoom()
    {
        Teleport(SearchRoom, SearchRoomCamera);
    }

    public void toSearch()
    {
        Teleport(Search, SearchCamera);
    }
    public void toLobby() {
        Teleport(Lobby, LobbyCamera);
    }

    public void ToMaze()
    {
        Teleport(Maze, MazeCamera, true);
        playerLight.enabled = true;
        CameraScript.Follow = true;
    }

    public void Teleport(Transform target, Transform cameraTarget, bool inMaze = false)
    {
        Camera.transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, Camera.transform.position.z);
        Player.transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        player.inMaze = inMaze;
    }
}
