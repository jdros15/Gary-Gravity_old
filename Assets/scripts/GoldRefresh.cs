using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldRefresh : MonoBehaviour {

    public PlayerGold pGold;
    public Text goldText;
	// Use this for initialization
	void Start () {

        goldText.text = PlayerPrefs.GetInt("PlayerGold").ToString();
	}
	
	// Update is called once per frame
	void Update () {
        goldText.text = PlayerPrefs.GetInt("PlayerGold").ToString();
	}
}
