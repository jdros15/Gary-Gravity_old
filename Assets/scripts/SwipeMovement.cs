using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class SwipeMovement : MonoBehaviour {

    public Slider healthBarSlider, boostbarSlider;
	public string currentLane;
	public GameObject target1,target2,target3,protag,charMesh,smokeTrail,character;
	public Vector3 targetPosition,currentPosition;
    public float upSpeed, sideSpeed, angleLeft, angleRight, swipeCap, boostCap;
    public static bool moveUp;
    SpriteRenderer tornadoSprite, tornadoSprite2;
    Animation anim;
    public float rotateQuat=90;
	// Use this for initialization
	void Start () {
      
        boostbarSlider.maxValue = boostCap;
        boostbarSlider.value = boostCap;
        healthBarSlider.maxValue = swipeCap;
        healthBarSlider.value = swipeCap;
		currentLane = "Lane2";
		targetPosition = target2.transform.position;
        moveUp = true;

	}
	
	// Update is called once per frame


	void Update() {

        character = GameObject.FindGameObjectWithTag("character");
        anim = character.GetComponent<Animation>();
        protag = GameObject.FindGameObjectWithTag("Player");
        GameObject tornadoSide = GameObject.Find("bag tornado side moveLeft");
        GameObject tornadoSide2 = GameObject.Find("bag tornado side moveRight");
        tornadoSprite = tornadoSide.GetComponent<SpriteRenderer>();
       tornadoSprite2 = tornadoSide2.GetComponent<SpriteRenderer>();

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane

			if (touchDeltaPosition.x > 1 && swipeCap >=1 && Time.timeScale == 1f)
			{
				//SwipeRight
                if (currentLane == "Lane2" && protag.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
				 	targetPosition = target3.transform.position; 
				}
                if (currentLane == "Lane1" && protag.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
			        targetPosition = target2.transform.position;
				}     
                anim.Play("shopper_girl_moveRight");
                tornadoSprite2.enabled = true;
                GameObject objSfxSwipe = GameObject.Find("sfxSwipeShopper_girl");
                AudioSource asSfxSwipe = objSfxSwipe.GetComponent<AudioSource>();
                asSfxSwipe.Play();
            }
            else if (touchDeltaPosition.x < -1 && swipeCap >= 1 && Time.timeScale == 1f)
			{
				//SwipeLeft
                
                if (currentLane == "Lane2" && protag.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
				//	currentLane = "Lane1";
					targetPosition = target1.transform.position;
                //   setSwipeCap();
				}
                if (currentLane == "Lane3" && protag.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
				//	currentLane = "Lane2";
					targetPosition = target2.transform.position;
                 //  setSwipeCap();
				}
                anim.Play("shopper_girl_moveLeft");
                tornadoSprite.enabled = true;
                GameObject objSfxSwipe = GameObject.Find("sfxSwipeShopper_girl");
                AudioSource asSfxSwipe = objSfxSwipe.GetComponent<AudioSource>();
                asSfxSwipe.Play();
			}
            Invoke("disableTornadoSprite", 0.5f);
          
		}

   

        MovePlayer();

	}

    void disableTornadoSprite(){
        tornadoSprite.enabled = false;
        tornadoSprite2.enabled = false;
    }
	private void MoveTowardsTarget() {
		//the speed, in units per second, we want to move towards the target

		//move towards the center of the world (or where ever you like)
		//targetPosition = maintarget.transform.position;

		currentPosition = protag.transform.position;
        
		//first, check to see if we're close enough to the target
		if(Vector3.Distance(currentPosition, targetPosition) > .1f) { 
			Vector3 directionOfTravel = targetPosition - currentPosition;
			//now normalize the direction, since we only want the direction information
			directionOfTravel.Normalize();
			//scale the movement on each axis by the directionOfTravel vector components

			
			protag.transform.Translate( 
				(directionOfTravel.x * sideSpeed * Time.deltaTime),
                (directionOfTravel.y * sideSpeed * Time.deltaTime),
                (directionOfTravel.z * sideSpeed * Time.deltaTime),
				Space.World);
		}
	}

    private void MovePlayer()
    {
        try
        {
            protag.transform.position = Vector3.Lerp(protag.transform.position, targetPosition, Time.deltaTime * 2);
        }
        catch (Exception e)
        {
            //do nothing
        }
    }

    public void setSwipeCap()
    {
        --swipeCap;
        healthBarSlider.value -= 1f;
    }
 

  
}
