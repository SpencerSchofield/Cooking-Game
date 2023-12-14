using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTest2
{
	
	GameObject aPoint;
	
	// Start is called before the first frame update
	void Start()
	{
		aPoint = GameObject.Find("FirePit").transform.GetChild(0).gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
