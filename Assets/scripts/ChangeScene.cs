using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {


	public string GoTo;
	public float waitTime;
	public GameObject fader,buttons;
	Animator animation,slide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void changeScene(){
		animation = fader.GetComponent<Animator> ();
		slide = buttons.GetComponent<Animator> ();
		animation.SetBool("FadeIn",true);
		slide.SetBool ("SlideOut", true);
		Invoke ("GoToScene", waitTime);

	}
	void GoToScene(){
		
        SceneManager.LoadScene(GoTo);
	}


}
