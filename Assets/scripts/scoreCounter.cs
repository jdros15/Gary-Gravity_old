using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {

	public int count;
	Text countText;
    bool stopScore;
	private GameObject obstacles;
	// Use this for initialization
	void Start () {
        countText = GameObject.Find("ScoreText").GetComponent<Text>();
		count = 0;
		setCountText ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    void OnTriggerEnter(Collider obstacles)
    {
        if (obstacles.gameObject.CompareTag("Obstacles") && stopScore == false)
        {
            count = count + 1;
            setCountText();
        }

    }

   

	void setCountText(){

		countText.text = count.ToString ();
	}

    public void stopScoring(bool playerIsDead)
    {
        if (playerIsDead == true)
        {
            stopScore = true;
        }
    }

}
