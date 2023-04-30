using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform target;
    private static bool cameraExists;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate ()
	{
		Vector3 newPosition = new Vector3 (target.position.x,target.position.y,transform.position.z);
		transform.position = newPosition;
        newPosition.z = -15; // camera z axis
        newPosition.y = -1; // camera y axis
    }

}
