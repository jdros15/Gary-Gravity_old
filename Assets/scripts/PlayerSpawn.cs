using UnityEngine;
using System.Collections;
using System;

public class PlayerSpawn : MonoBehaviour {

	public GameObject protag;
	public Transform spawnLoc;
//	private GameObject spawnObj;
	// Use this for initialization
	void Start () {
		//spawnObj = GameObject.FindGameObjectWithTag ("Player");
        protag = (GameObject)Resources.Load("Characters/"+ PlayerPrefs.GetString("chosenChar"), typeof(GameObject));
		Instantiate(protag, spawnLoc.position, spawnLoc.rotation);
       /* try
        {
            spawnObj.transform.parent = transform;
        }
        catch (Exception e)
        {

        }*/
	}
	
	// Update is called once per frame
	void Update () {
	}
}
