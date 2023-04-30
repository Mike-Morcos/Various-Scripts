//----------------------------------------------------
using System.Collections;
using UnityEngine;
//----------------------------------------------------
public class Wall_Spawner : MonoBehaviour
{
	public GameObject[] spawnObject;

	public float rangeY = 1.0f;
	public float rangeX = 1.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	//------------------------------------------------
	void Start()
    {
		Invoke("SpawnWall", Random.Range(minSpawnTime, maxSpawnTime));

    }
	//------------------------------------------------
	void spawnWall()
    {
		float offsetX = Random.Range(-rangeX, rangeX);
		float offsetY = Random.Range(-rangeY, rangeY);
		int spawnObjectIndex = Random.Range(0, spawnObject.Length);

		Instantiate(spawnObject[spawnObjectIndex], transform.position + 
		new Vector3(rangeX,rangeY,0.0f),spawnObject[spawnObjectIndex].transform.rotation);

		Invoke("SpawnWall", Random.Range(minSpawnTime, maxSpawnTime));

	}
}
