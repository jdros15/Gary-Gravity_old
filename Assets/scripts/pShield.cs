﻿using UnityEngine;
using System.Collections;

public class pShield : MonoBehaviour {


    public int shieldLeft;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider playerCollider)
    {
        
        if (playerCollider.gameObject.tag == "Obstacles")
        {
            Destroy(playerCollider);
            gameObject.SetActive(false);
        }


    }
}
