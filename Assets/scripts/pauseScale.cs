﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseScale : MonoBehaviour {


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
	

	}
    public void Playgame()
    {
        Time.timeScale = 1f;
        cam.SendMessage("TurnBlurOff");


    }
}
