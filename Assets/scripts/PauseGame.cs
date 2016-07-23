using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {


	Camera cam;
	//private Blur Blurscript;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Pause(){
		Time.timeScale = 0f;
		cam.SendMessage ("TurnBlurOn");
		GameObject.Find ("Pause").GetComponent<Button>().enabled = false;
		GameObject.Find ("Score").GetComponent<Text>().enabled = false;
		GameObject.Find ("Pause").transform.localScale = new Vector3 (0, 0, 0);
		GameObject.Find ("Score").transform.localScale = new Vector3 (0, 0, 0);

	}
}
