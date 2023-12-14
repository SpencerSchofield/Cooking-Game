using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTest : MonoBehaviour
{
	/*
	!!Holy shit I actually figured this problem out, Can't actually believe it lol. My current thoughts on how to further implement this:
	I need to add more empty game objects to "FirePit" and I dont think I need to use Blender but if I do modelling later on I can always
	add the	attachment points directly to the model. Once I set the attachment points up I need to shoot a raycast before letting go of my
	object and check if it hits an object tagged with "Interactable". If true then I need to set the transform position of the "Food Item"
	to the first attachment point and if I place a second down I need a way to make sure the game knows the first point is taken. I may later 
	be able to change this and have the object hover over the exact attachment point I want the object to be placed on. Also side note might 
	want to check out UnityActions to setup observer classes. 
	*/
	
	Rigidbody rb;
	public GameObject FirePit;
	GameObject _aPoint1;
	GameObject _aPoint2;
	GameObject _aPoint3;
	GameObject _aPoint4;
	GameObject _aPoint5;
	
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		_aPoint1 = FirePit.transform.GetChild(0).gameObject;
		_aPoint2 = GameObject.Find("FirePit").transform.GetChild(1).gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		rb.position = _aPoint2.transform.position;
	}
}
