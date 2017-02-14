using UnityEngine;
using System.Collections;

public class RdmObjGen : MonoBehaviour {

    

	public Transform[] SpawnPoints;
	public float spawnTimeObs,minSpawnTimeObs,maxSpawnTimeObs,spawnTimeCol,minSpawnTimeCol,maxSpawnTimeCol;
	//public GameObject Obstacles;
 	public GameObject[] Obstacles,Collectibles;
    public bool invokeCollectibles,stopBoostNow,stopShieldNow,stopAttackNow;
	// Use this for initialization
	void Start () {

        invokeCollectibles = false ;
        InvokeRepeating("SpawnObstacles", spawnTimeObs, spawnTimeObs);
       
	}
	

	// Update is called once per frame
	void Update () {
        if (invokeCollectibles == true)
        {
            invokeCollectibles = false;
            InvokeRepeating("SpawnCollectibles", spawnTimeCol, spawnTimeCol);

        }

        if (stopBoostNow) Destroy(GameObject.FindGameObjectWithTag("CollectiblesBoost"));
        if (stopShieldNow) Destroy(GameObject.FindGameObjectWithTag("CollectiblesShield"));
        if (stopAttackNow) Destroy(GameObject.FindGameObjectWithTag("CollectiblesAttack"));
        }

	void SpawnObstacles() {
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		int obstaclesIndex = Random.Range (0, Obstacles.Length);
		Instantiate(Obstacles[obstaclesIndex], SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);
        spawnTimeObs = Random.Range(minSpawnTimeObs, maxSpawnTimeObs);
	}

    void SpawnCollectibles()
    { 
        int spawnIndex1 = Random.Range(0, SpawnPoints.Length);
        int obstaclesIndex1 = Random.Range(0, Collectibles.Length);
        Instantiate(Collectibles[obstaclesIndex1], SpawnPoints[spawnIndex1].position, SpawnPoints[spawnIndex1].rotation);
        spawnTimeCol = Random.Range(minSpawnTimeCol, maxSpawnTimeCol);
    }
}
