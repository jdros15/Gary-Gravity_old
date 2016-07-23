using UnityEngine;
using System.Collections;

public class RdmObjGen : MonoBehaviour {


	public Transform[] SpawnPoints;
	public float spawnTime;
	public float minSpawnTime;
	public float maxSpawnTime;
	//public GameObject Obstacles;
 	public GameObject[] Obstacles;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnObstacles",spawnTime,spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnObstacles() {
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		int obstaclesIndex = Random.Range (0, Obstacles.Length);
		Instantiate(Obstacles[obstaclesIndex], SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);
	}
}
