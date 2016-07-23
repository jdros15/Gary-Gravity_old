using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {

	public int count;
	public Text countText;
	private GameObject obstacles;
	// Use this for initialization
	void Start () {
		count = 0;
		setCountText ();;
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter(Collider obstacles){
		if (obstacles.gameObject.CompareTag("Obstacles")){
			count = count + 1;
			setCountText ();
		}
	}

	void setCountText(){
		countText.text = count.ToString ();
	}

}
