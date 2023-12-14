using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound_Within_CameraView : MonoBehaviour
{
	/*
	ISSUE: When object is touching the bounds of the screen it looks like its actually slowing down the game, Might need to optimize this later
	*/
	Rigidbody rb;
	Vector2 cameraBounds;

	float objectDistFromCamera;
	float rightBorder;
	float leftBorder;
	float topBorder;
	float bottomBorder;
	Vector3 objectSize;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		/*
		The 6 lines of code below are what I need to get this function to work properly. First I need to check if the object has surpassed
		any of the 4 borders, if it has, set it position back into camera frustrum.
		*/
		objectDistFromCamera = (this.transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, objectDistFromCamera)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, objectDistFromCamera)).x;
		topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, objectDistFromCamera)).y;
		bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, objectDistFromCamera)).y;
		objectSize = this.gameObject.GetComponent<Renderer>().bounds.size;

		Debug.Log("objectDistFromCamera = " + objectDistFromCamera);
		Debug.Log("left Border = " + leftBorder);
		Debug.Log("right Border = " + rightBorder);
		Debug.Log("Screen Width: " + Screen.width);
		Debug.Log("Screen Height: " + Screen.height);
	}

	// Update is called once per frame
	void Update()
	{
		/*
		!!May need to add this code when working to the coroutine ObjectFollowMouse, as the mouse
		can move the object outside of the view and until the player lets go of the object it will not
		return to the camera bounds <-- This is no longer an issue and should be left within its own script
		*/
		

		/*
		!! May want to have this within an if statement later on for optimisation
		*/
		
		this.transform.position = new Vector3(
		Mathf.Clamp(this.transform.position.x, leftBorder + objectSize.x / 2, rightBorder - objectSize.x / 2),
		Mathf.Clamp(this.transform.position.y, topBorder + objectSize.y / 2, bottomBorder - objectSize.y / 2),
		this.transform.position.z
		); //<-- This one line of code confines the object within the camera view and works on any z axis (unless really far away)



	}
}
