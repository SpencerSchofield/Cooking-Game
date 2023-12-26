using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverKnife : MonoBehaviour
{
	/*
	Script to have the knife hover over cPoints on Food objects to knife where to chop the item. 
	If knife is within collider box(cPoint) then have the knife hover object a specific point until the player mouse moves
	outside of the collider box(cPoint)
	
	Can use PlayerState.HoldingKnife to know when player is using the knife. I may want to later move this script into
	ChopFood or Player_Mouse script, not sure if its better to have them seperate or not (need to research)
	*/
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
