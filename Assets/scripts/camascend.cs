using UnityEngine;
using System.Collections;

public class camascend : MonoBehaviour {

	public int MoveSpeed = 0;
	bool touched = false;
	void Update () {
		/*if (Input.GetTouch(0).phase == TouchPhase.Began)
		{
			touched = true;
		}
		if (touched == true)
		{
			transform.Translate ((Vector3.up * (Time.deltaTime * MoveSpeed)), Space.World);
		}*/
		transform.Translate ((Vector3.up * (Time.deltaTime * MoveSpeed)), Space.World);
	}

}
