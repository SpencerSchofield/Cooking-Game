using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodManager : MonoBehaviour
{
	//This script should be applied to all Food prefabs.
	//Make a list and add all CPoints to it
	//also need box colliders on the whole food plus each chopped part.
	//remove Cpoint when chopped and active individual chopped box colliders

	public List<GameObject> cPoints;
	public static event Action OnKnifeHeldTest;
	
	public BoxCollider cP1;
	public BoxCollider cP2;

	// Start is called before the first frame update
	void Start()
	{
		List<BoxCollider> cPoints = new List<BoxCollider>();
		GetChopPoints();
		Actions.OnKnifeHeld?.Invoke();
	}

	/*
	Get the Chop points of this object. Want to use a foreach to add to list - this would be better as I can loop
	through different foods that might have more or less chop points. I.e. fish and meat have 2 cPoints and mushroom only has 1.
	*/
	void GetChopPoints()
	{
		cP1 = this.transform.GetChild(0).GetComponent<BoxCollider>();
		cP2 = this.transform.GetChild(1).GetComponent<BoxCollider>();
		//cPoints.Add(this.transform.GetChild(0).GetComponent<BoxCollider>());
		cPoints.Add(this.transform.GetChild(0).gameObject);
		Debug.Log("Actions");
	}
	void testFunc()
	{
		Debug.Log("Action actioned");
	}
	
	/*
	Activates when playerState == Usingknife.
	Toggles the chop points on all Food on scene on/off depending if the knife is held
	*/
	void ToggleChopPoints()
	{
		cP1.enabled = !cP1.enabled;
		cP2.enabled = !cP2.enabled;
		
		//	cPoints[0].GetComponent<BoxCollider>.enabled();
		// cPoints[1].enabled = cPoints[1].enabled;
	}
	

	void OnEnable()
	{
		Actions.OnKnifeHeld += testFunc;
		Actions.OnKnifeHeld += ToggleChopPoints;//Subscribe to listen for when OnKnifeHeld is triggered.
	}
	void OnDisable()
	{
		Actions.OnKnifeHeld -= testFunc;
		Actions.OnKnifeHeld -= ToggleChopPoints;//Unsubscribe when object is deleted or disabled.
	}

}
