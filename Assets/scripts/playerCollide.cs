﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerCollide : MonoBehaviour {

   // public Collider playerCollide ;

	// Use this for initialization
    Camera cam;
    camdescend pDescend;
    GameObject character, player, goPanel, btnPause, ui, maincam, boostLane;
    Button btnShield,btnAttack,btnBoost;
    // GameObject playerObj;
    scoreCounter scoring;
    SwipeMovement swipeScript;
    Animator gameover;
    public Slider healthbarSlider,boostbarSlider;
    RdmObjGen rdmobj;
    bool invokeCollectiblesOnce = false;
    Animation anim;


	void Start () {
   
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        boostLane = GameObject.Find("BoostLane");
        healthbarSlider = GameObject.Find("healthSlider").GetComponent<Slider>();
        boostbarSlider = GameObject.Find("boostSlider").GetComponent<Slider>();
        ui = GameObject.Find("UI");
        maincam = GameObject.Find("Main Camera");
        cam = Camera.main;
        btnPause = GameObject.Find("Pause");
        goPanel = GameObject.Find("goPanel");
        gameover = goPanel.GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("character");
        player = GameObject.FindGameObjectWithTag("Player");
        scoring = GameObject.Find("subScoreCounter").GetComponent<scoreCounter>();
        pDescend = player.gameObject.GetComponent<camdescend>();
        anim = GameObject.FindGameObjectWithTag("character").GetComponent<Animation>();
        btnShield = GameObject.Find("btnShield").GetComponent<Button>();
        btnAttack = GameObject.Find("btnAttack").GetComponent<Button>();
        btnBoost = GameObject.Find("btnBoost").GetComponent<Button>();
 
	}
	
	// Update is called once per frame
	void Update () {
        //try lang movement
        //playerObj.transform.Rotate(Vector3.back * Time.deltaTime * rotSpeedX);

        if (boostbarSlider.value == boostbarSlider.maxValue)
        {
           // regenBoostNow = false;
           
            CancelInvoke("regenBoostInvoked");
            rdmobj.stopBoostNow = false;
            print("boost resumed");
            if (!invokeCollectiblesOnce)
            {
                rdmobj.invokeCollectibles = true;
                invokeCollectiblesOnce = true;
            }
        }

        if (boostbarSlider.value <= 0f)
        {
           
            regenBoost();
        }
  
        	}

    void regenBoost()
    {

        InvokeRepeating("regenBoostInvoked", 4, 4);
        
    }

    void regenBoostInvoked(){
        boostbarSlider.value += 0.005f;
        swipeScript.boostCap += 0.005f;
        invokeCollectiblesOnce = !invokeCollectiblesOnce;
    }

    void OnTriggerEnter(Collider playerCollider)
    {

        if (playerCollider.gameObject.tag == "Obstacles")
        {
            // game over
           

            gameover.SetBool("isGameOver", true);
            character.GetComponent<Animation>().CrossFade("shopper_dead_top");
            GameObject subScoreCounter = GameObject.Find("subScoreCounter");
            Destroy(subScoreCounter);
          pDescend.enabled = true;
          scoring.stopScoring(true);
          btnPause.SetActive(false);
          cam.SendMessage("TurnBlurOn");
          ui.SetActive(false);
        }

        if (playerCollider.gameObject.tag == "CollectiblesCap")
        {
            // collectible capacity
            swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
            swipeScript.swipeCap = healthbarSlider.maxValue;
            healthbarSlider.value = healthbarSlider.maxValue;
            Destroy(playerCollider.gameObject);
            print("cap collided");
        }

        if (playerCollider.gameObject.tag == "CollectiblesBoost")
        {
            // collectible boost

            btnBoost.interactable = true;
            rdmobj.stopBoostNow = true;
            Destroy(playerCollider.gameObject);

        }

        if (playerCollider.gameObject.tag == "CollectiblesShield")
        {
            // collectible shield

            btnShield.interactable = true;


            rdmobj.stopShieldNow = true;
            Destroy(playerCollider.gameObject);

        }

        if (playerCollider.gameObject.tag == "CollectiblesAttack")
        {
            // collectible attack
            rdmobj.stopAttackNow = true;
            btnAttack.interactable = true;
            Destroy(playerCollider.gameObject);
            
        }
    }

    public void startBoost()
    {
        anim.CrossFade("shopper_girl_spin");
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
        swipeScript.targetPosition = boostLane.transform.position;
        Time.timeScale = 4f;
        btnPause.GetComponent<Button>().interactable = false;
        rdmobj.stopBoostNow = true;
        InvokeRepeating("decBoost", 4, 4);
    }

    void Unboost()
    {
        swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
        swipeScript.currentLane = "Lane2";
        btnPause.GetComponent<Button>().interactable = true;
        anim.CrossFade("shopper_idle_anim_001");
        swipeScript.targetPosition = swipeScript.target2.transform.position;
        Time.timeScale = 1f;
        //destroy all obstacles
        GameObject[] obs = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject ob in obs)
        {
            Destroy(ob);
        }

        //destroy collectiblecaps
        GameObject[] obscap = GameObject.FindGameObjectsWithTag("CollectiblesCap");
        foreach (GameObject obcap in obscap)
        {
            Destroy(obcap);
        }

        //destroy collectibleboost
        GameObject[] obsboost = GameObject.FindGameObjectsWithTag("CollectiblesBoost");
        foreach (GameObject obboost in obsboost)
        {
            Destroy(obboost);
        }

       
    }

    void decBoost()
    {
        if (swipeScript.boostCap >= 1f)
        {
            
            swipeScript = maincam.gameObject.GetComponent<SwipeMovement>();
            swipeScript.boostCap -= 1f;
            boostbarSlider.value -= 1f;
        }else 
        {
            //regenBoostNow = true;
            CancelInvoke("decBoost");
            Unboost();
        }
    }


    

    
}