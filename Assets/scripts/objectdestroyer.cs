using UnityEngine;
using System.Collections;
using System;
using UnityEditor.SceneManagement;

public class objectdestroyer : MonoBehaviour {

	// Use this for initialization
    public GameObject explosion,btnShieldObj;
    public Boolean isDestroyer = false;
    shieldToggle shieldToggleScript;
	void Start () {
        btnShieldObj = GameObject.Find("btnShield");
        if (EditorSceneManager.GetActiveScene().name == "Game" ) shieldToggleScript = btnShieldObj.GetComponent<shieldToggle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider obj)
    {
       /* if (obj.gameObject.tag == "Foreground" || obj.tag == "Obstacles")
        {
            Destroy(obj.gameObject);
            if (isDestroyer == false)
            {
                try
                { Instantiate(explosion, transform.position, transform.rotation); }
                catch (Exception e) { }
                shieldToggleScript.deactivateShield();
                if (gameObject.tag == "PowerAttack")
                {
                    Destroy(gameObject);
                }
            }
        }*/

        if (isDestroyer && (obj.tag == "Foreground" || obj.tag == "Obstacles"))
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
           
        }
    }
}
