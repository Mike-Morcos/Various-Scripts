// Author: Michael Morcos
// Date: 5/25/2019
// This script will

using UnityEngine;

public class Laser_spawn : MonoBehaviour {

#region Varaibles
	public GameObject laser;
	public Transform player;
	public Transform snowClops;
	public Transform firePoint;
	float delayTimer = 1f;
	float timer;
#endregion

	void Start ()
	{
		timer = delayTimer;	
	}	
	private void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0 && player.position.x < snowClops.position.x + 5 && player.position.x > snowClops.position.x && player.position.y < snowClops.position.y + 1 && player.position.y > snowClops.position.y - 1)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			Instantiate(laser, transform.position, transform.rotation);
			
			timer = delayTimer;
		}
		if (timer <= 0 && player.position.x > snowClops.position.x - 5 && player.position.x < snowClops.position.x && player.position.y < snowClops.position.y + 1 && player.position.y > snowClops.position.y - 1)
		{
			firePoint.rotation = Quaternion.Euler(0, 0, 180);
			Instantiate(laser, transform.position, transform.rotation);

			timer = delayTimer;
		}
		if (timer <= 0 && player.position.y < snowClops.position.y + 5 && player.position.y > snowClops.position.y && player.position.x < snowClops.position.x + 1 && player.position.x > snowClops.position.x - 1)
		{
			transform.rotation = Quaternion.Euler(0, 0, 90);
			Instantiate(laser, transform.position, transform.rotation);

			timer = delayTimer;
		}
		if (timer <= 0 && player.position.y > snowClops.position.y - 5 && player.position.y < snowClops.position.y && player.position.x < snowClops.position.x + 1 && player.position.x > snowClops.position.x - 1)
		{
			firePoint.rotation = Quaternion.Euler(0, 0, 270);
			Instantiate(laser, transform.position, transform.rotation);

			timer = delayTimer;
		}

	}
	
}
