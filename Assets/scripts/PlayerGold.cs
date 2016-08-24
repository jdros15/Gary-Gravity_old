using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour {
    public Text curGold;
	// Use this for initialization
	void Start () {
	//check if gold key exists
        if (PlayerPrefs.HasKey("PlayerGold"))
        {
            //print to PlayerGold
            curGold.text  = PlayerPrefs.GetInt("PlayerGold").ToString();
        }
        else
        {
            //make a key
            PlayerPrefs.SetInt("PlayerGold", 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
