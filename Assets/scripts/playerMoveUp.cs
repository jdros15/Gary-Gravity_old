using UnityEngine;
using System.Collections;

public class playerMoveUp : MonoBehaviour {
    public GameObject protag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider moveUp)
    {
        if (moveUp.gameObject.CompareTag("Player"))
        {
            SwipeMovement.moveUp = true;

        }
    }
}
