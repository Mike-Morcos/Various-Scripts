//-----------------------------------------------------------------
using System.Collections;
using UnityEngine;
//-----------------------------------------------------------------

public class Enemy_Spawner : MonoBehaviour
{
#region Variables
	public GameObject[] Enemy;
	// Range for game objects to spawn within the screen.
	public float spawnBoundary = 3f;
	// Time by witch we want the timer to be delayed
	public float timerDelay = 1f;
	// Spawns object after specific time.
	float timer;
	// Enter comment
	// enum gameObj { Asteroid, ship};
	int spawnTime = 1;
#endregion
	//-----------------------------------------------------------------
	void Start()
    {
		// Assigns timerDelay value to timer.
		timer = timerDelay;

	}
	//-----------------------------------------------------------------
	void Update()
    {
		// Each frame the value of the timer will be decremented until
		// its value is zero.
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			
			
			// Creates a temporary position for the object spawner within a random
			// range on the x axis.                          -3              3
			Vector3 randomPosX = new Vector3(Random.Range(-spawnBoundary, spawnBoundary),
			transform.position.y, transform.position.z);
			// Instantiates a game object to the empty asteroidSpawner with
			// a random Xposition and rotation. 
			if (spawnTime > 0 && spawnTime < 4)
			{
				// Asteroid
				Instantiate(Enemy[0], randomPosX, transform.rotation);
				spawnTime++;
				//Destroy(Enemy[0].gameObject);
				
			}
			// CREATES ERROR IF THERE IS NO ENEMY
			else if (spawnTime == 4)
			{
				// Enemy ship
				Instantiate(Enemy[1], randomPosX, transform.rotation);
				spawnTime = 1;
				
			}
			// Resets the timer variable to the timerDelay variable.
			timer = timerDelay;
		}
		
	}
}
