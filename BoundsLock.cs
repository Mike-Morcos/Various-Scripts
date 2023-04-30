//------------------------------
using UnityEngine;
using System.Collections;
//------------------------------
public class BoundsLock : MonoBehaviour
{
	//------------------------------
	public Transform ThisTransform;
	//Can be changed from inspector
	public Vector2 HorzRange = Vector2.zero;
	public Vector2 VertRange = Vector2.zero;
	//------------------------------
	// Use this for initialization
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}
	//------------------------------
	void LateUpdate()
	{
		//Clamp position
		ThisTransform.position = new Vector3(Mathf.Clamp
		(ThisTransform.position.x, HorzRange.x, HorzRange.y),
		ThisTransform.position.y,
		Mathf.Clamp(ThisTransform.position.z, VertRange.x,
		VertRange.y));
	}
	//------------------------------
}
//------------------------------

/* The following points summarize the code sample:
 
	• The LateUpdate function is always called after all the FixedUpdate and
Update calls, allowing an object to modify its position before it's rendered to
the screen. More information on LateUpdate can be found at http://docs.
unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html.

	• The Mathf.Clamp function ensures that a specified value is capped between
a minimum and maximum range.

	• To use the BoundsLock script, simply drag and drop the file to the Player
object and specify minimum and maximum values for its position. These
values are specified in world position coordinates and can be determined by
temporarily moving the Player object to the camera extremes and recording
its position from the Transform component:
	 */
