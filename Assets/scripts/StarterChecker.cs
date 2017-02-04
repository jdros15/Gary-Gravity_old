using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarterChecker : MonoBehaviour {

	// Use this for initialization
    GameObject objBoost, objAttack, objShield, maincam;
    Button btnBoost,btnAttack,btnShield;
    RdmObjGen rdmobj;
	void Start () {
        if (PlayerPrefs.HasKey("endTimeBoost"))
        {
            objBoost = GameObject.Find("btnBoost");
            btnBoost = objBoost.GetComponent<Button>();
            btnBoost.interactable = true;
        }

        if (PlayerPrefs.HasKey("endTimeAttack"))
        {
            objAttack = GameObject.Find("btnAttack");
            btnAttack = objAttack.GetComponent<Button>();
            btnAttack.interactable = true;
        }

        if (PlayerPrefs.HasKey("endTimeShield"))
        {
            objShield = GameObject.Find("btnShield");
            btnShield = objShield.GetComponent<Button>();
            btnShield.interactable = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	        
	}
}
