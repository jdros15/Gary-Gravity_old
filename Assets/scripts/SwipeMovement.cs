using UnityEngine;
using System.Collections;

public class SwipeMovement : MonoBehaviour {
	public string currentLane;
	public GameObject target1,target2,target3,protag;
	public Vector3 targetPosition,currentPosition;
	public float speed;
	// Use this for initialization
	void Start () {
		currentLane = "Lane2";
		targetPosition = target2.transform.position;

	}
	
	// Update is called once per frame

	void Update() {



		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Move object across XY plane
			//transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			if (touchDeltaPosition.x > 1)
			{
				//SwipeRight
				if (currentLane == "Lane2") {
					currentLane = "Lane3";
					targetPosition = target3.transform.position;
				
				}
				if (currentLane == "Lane1") {
					currentLane = "Lane2";
					targetPosition = target2.transform.position;
				}

			}else if (touchDeltaPosition.x < -1)
			{
				//SwipeLeft
				if (currentLane == "Lane2") {
					currentLane = "Lane1";
					targetPosition = target1.transform.position;
				}
				if (currentLane == "Lane3") {
					currentLane = "Lane2";
					targetPosition = target2.transform.position;
				}
			
			}

		}
		MoveTowardsTarget ();
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

			protag.transform.Translate(protag.transform.up * Time.deltaTime * speed, Space.Self); 
			/*protag.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);*/
		}
	}
}
