using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class btnTimersScript : MonoBehaviour {

    public GameObject timersPanel; //  1. declare the object that contains the animation
    public Sprite timerCollapse, timerRestore;
    Animator anim;  // 2. declare a name for the animator
    Image btnSprite;
    bool isShown = false;


	void Start () {
        btnSprite = GetComponent<Image>();  
        anim = timersPanel.GetComponent<Animator>();  // 3. do this to get the animation from object to animator variable
	}
	

	void Update () {
	
	}


    public void showTimers()
    {
        if (isShown == false)
        {
            anim.SetBool("showTimers", true); // 4. do this to modify a boolean parameter condition from the Animator
            btnSprite.sprite = timerRestore;
            isShown = true; 
        }
        else
        {
        
            anim.SetBool("showTimers", false);
            btnSprite.sprite = timerCollapse;
            isShown = false;
        }
    }
}
