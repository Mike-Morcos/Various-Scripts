using UnityEngine;

public class Player_start_point : MonoBehaviour {

    private Player_Controller thePlayer;
    private Camera_Controller theCamera;

    public Vector2 startDirection;


    void Start()
    {
        thePlayer = FindObjectOfType<Player_Controller>();
        thePlayer.transform.position = transform.position;
        //thePlayer.lastMove = startDirection;

        theCamera = FindObjectOfType<Camera_Controller>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
    }





}
