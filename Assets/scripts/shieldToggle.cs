﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shieldToggle : MonoBehaviour {

	// Use this for initialization
    GameObject pShield,sprPlayerShield;
    Button btnShield;
    RdmObjGen rdmobj;
  
	void Start () {
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        btnShield = gameObject.GetComponent<Button>();
        
	}

    void Update(){
        
    
  
      }

    void activateShield()
    {
        pShield = GameObject.Find("playerShield");
        Collider col = pShield.GetComponent<Collider>();
        col.enabled = true;
        sprPlayerShield = GameObject.Find("sprite_playerShield");
        SpriteRenderer ren = sprPlayerShield.GetComponent<SpriteRenderer>();
        ren.enabled = true;
        
    }

    public void deactivateShield()
    {
        pShield = GameObject.Find("playerShield");
        Collider col = pShield.GetComponent<Collider>();
        col.enabled = false;
        sprPlayerShield = GameObject.Find("sprite_playerShield");
        SpriteRenderer ren = sprPlayerShield.GetComponent<SpriteRenderer>();
        ren.enabled = false;
    }
	
	// Update is called once per frame
	

    public void onShield()
    {
      
            rdmobj.stopShieldNow = false;
            activateShield();
            btnShield.interactable = false;
        
    }
}
