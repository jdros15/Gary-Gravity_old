using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBoost : MonoBehaviour {
    Animation anim;
    SwipeMovement swipeScript;
    GameObject maincam, btnPause, boostLane;
    RdmObjGen rdmobj;
    playerCollide pCollideScript;
	// Use this for initialization
	void Start () {
        rdmobj = GameObject.Find("RdmGen").GetComponent<RdmObjGen>();
        boostLane = GameObject.Find("BoostLane");
        maincam = GameObject.Find("Main Camera");
        pCollideScript = GameObject.FindGameObjectWithTag("character").GetComponent<playerCollide>();
        anim = GameObject.FindGameObjectWithTag("character").GetComponent<Animation>();
        btnPause = GameObject.Find("Pause");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startBoost()
    {
        // collectible boost
        Button btnBoost = gameObject.GetComponent<Button>();
        btnBoost.interactable = false;
        pCollideScript.startBoost();


        
    }

}
