using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class objectdestroyer : MonoBehaviour {

	// Use this for initialization
    public GameObject explosion,btnShieldObj;
    public Boolean isDestroyer = false;
    shieldToggle shieldToggleScript;
	void Start () {
        btnShieldObj = GameObject.Find("btnShield");
        if (SceneManager.GetActiveScene().name == "Game" ) shieldToggleScript = btnShieldObj.GetComponent<shieldToggle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider obj)
    {

     /*   if (isDestroyer && (obj.tag == "Foreground" || obj.tag == "Obstacles"))
        {
             Destroy(obj.gameObject);
        }
        else if (obj.tag == "Obstacles")
        {
            if ((gameObject.name == "playerShield" || gameObject.tag == "PowerAttack"))
            {
                
                try
                { Instantiate(explosion, transform.position, transform.rotation); }
                catch (Exception e) { }
                shieldToggleScript.deactivateShield();
                if (gameObject.tag == "PowerAttack")
                {
                    Destroy(gameObject);
                }
                Destroy(obj.gameObject);
            }
           
        } */

        if (isDestroyer && (obj.tag == "Foreground" || obj.tag == "Obstacles"))
        {
            Destroy(obj.gameObject);
        }
        else if(obj.tag == "Obstacles")
        {
            if (gameObject.name == "playerShield")
            {
                try
                { Instantiate(explosion, transform.position, transform.rotation); }
                catch (Exception e) { }
                shieldToggleScript.deactivateShield();
                Destroy(obj.gameObject);
                GameObject objSfxDestByShield = GameObject.Find("sfxDestroyedByShield");
                AudioSource asSfxDestByShield = objSfxDestByShield.GetComponent<AudioSource>();
                asSfxDestByShield.Play();
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                BoxCollider colPlayer = player.GetComponent<BoxCollider>();
                colPlayer.enabled=false;
             
            }
            else if (gameObject.tag == "PowerAttack")
            {
                GameObject objSfxDestByAttack = GameObject.Find("sfxDestroyedByAttack");
                AudioSource asSfxDestByAttack = objSfxDestByAttack.GetComponent<AudioSource>();
                asSfxDestByAttack.Play();

                Destroy(gameObject);
                Destroy(obj.gameObject);
            }
           
        }
    }
}
