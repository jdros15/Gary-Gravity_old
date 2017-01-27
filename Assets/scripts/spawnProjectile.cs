using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawnProjectile : MonoBehaviour {

	// Use this for initialization

    public GameObject projectile;
    Button btnAttack;
    public GameObject spawnPointProjectile;
    RdmObjGen rdmobj;
	void Start () {
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        spawnPointProjectile = GameObject.Find("spawnPointProjectile");
        btnAttack = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    public void fireProjectile()
    {
        rdmobj.stopAttackNow = false;
        Instantiate(projectile, spawnPointProjectile.transform.position, spawnPointProjectile.transform.rotation);
        btnAttack.interactable = false;
        
    }

 
}
