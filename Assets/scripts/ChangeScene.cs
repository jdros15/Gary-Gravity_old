using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {


	public string GoTo;
	public float waitTime;
	public GameObject fader,buttons;
	Animator anim,slide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void changeScene(){
        anim = fader.GetComponent<Animator>();
		slide = buttons.GetComponent<Animator> ();
        anim.SetBool("FadeIn", true);
		slide.SetBool ("SlideOut", true);
		Invoke ("GoToScene", waitTime);

	}
	void GoToScene(){
		
        SceneManager.LoadScene(GoTo);
	}


}
