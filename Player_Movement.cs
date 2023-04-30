//-------------------------------------------
// using System.Collections;
using UnityEngine;
//-------------------------------------------
public class Player_Movement : MonoBehaviour
{
	public float MaxSpeed = 5f;
	public float acceleration = 2f;

	private Rigidbody ThisBody = null;
	private Transform ThisTransform = null;
	//-------------------------------------------
	void Awake()
	{
		ThisBody = GetComponent<Rigidbody>();
		ThisTransform = GetComponent<Transform>();
	}
	//-------------------------------------------
	// FixedUpdate differs from Update, which is 
	// called once per frame and can vary on a per 
	// second basis as the frame rate fluctuates.
	void FixedUpdate()
	{
		
		// Storing axial data as a float.
		float Horz = Input.GetAxis("Horizontal");
		float Vert = Input.GetAxis("Vertical");
		
		// Gets the player facing forward vector.
		Vector3 Facingdirection = new Vector3(Horz, Vert, 15.0f);
		
		// Direction encoded in the MoveDirection vector based on
		// input from both the Horizontal and Vertical axes.
		Vector3 MoveDirection = new Vector3(Horz, Vert, 0.0f);
		
		// Updates movement
		ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);
		
		//--------------------------------------------------------------------
		// Rotate a GameObject using a Quaternion.
		// Tilt the cube using the arrow keys. When the arrow keys are released
		// the cube will be rotated back to the center using Slerp.

		float smooth = 5.0f;
		float tiltAngle = 60.0f;


		// Smoothly tilts a transform towards a target rotation.
		float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
		float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

		// Rotate the cube by converting the angles into a quaternion.
		Quaternion target = Quaternion.Euler(tiltAroundX *.20f, 0, tiltAroundZ );
		// Dampen towards the target rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		//-------------------------------------------------------------------------
		// rotates towards foward vector.
		ThisBody.AddTorque(transform.up * 100.0f );
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Facingdirection), Mathf.Deg2Rad * 50.0f);
		//-------------------------------------------------------------------------
		// Clamps the speed within a specified range.
		ThisBody.velocity = new Vector3
		(
			Mathf.Clamp(ThisBody.velocity.x, -acceleration, acceleration),
			Mathf.Clamp(ThisBody.velocity.y, -acceleration, acceleration),
			Mathf.Clamp(ThisBody.velocity.z, -acceleration, acceleration)
		);
		
	}
}
