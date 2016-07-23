using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	public GameObject protag;
	public Transform spawnLoc;
	private GameObject spawnObj;
	// Use this for initialization
	void Start () {
		spawnObj = GameObject.FindGameObjectWithTag ("Player");
		Instantiate(protag, spawnLoc.position, spawnLoc.rotation);
		spawnObj.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
