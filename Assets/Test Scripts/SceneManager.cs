using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

[System.Serializable]
public class SceneManager : MonoBehaviour
{
	[SerializeField] Player_Mouse player;
	FirePitHandler2 FirePit;
	GameObject Stove;
	GameObject Bin;
	//Need List
	GameObject[] attachmentPoints;//Instead of array might need I think a hash set or a 2d array to hold both the attachment points and bools if they're free
	
	//toString to maybe add the value of i to the name of an object ie apoint+i == apoint1 apoint2
	//Initatlise Firepit attachment points
	//plus Bin
	void Start()
	{
		Player_Mouse player = new Player_Mouse();
		FirePit = GetComponent<FirePitHandler2>();
		Stove= GameObject.Find("Stove");
		Bin = GameObject.Find("Bin");

	}

	/*
	Want a function that if player.holding then to make colliders visable and when
	player.Notholding I want attachment colliders to disapear.
	
	!! Works but cant keep this in update as it'll constatly change the state of the 
	attachment points and slow game down. Might also want to use a forloop but this works
	for now :)
	*/
	/*
	SetActiveAttachmentPoints() sets the attachment points on the FirePit in scene to active or
	deactive depending on if the player is holding an object. This is used so the colliders for the
	attachtment point dont block the player from grabbing the object again.
	*/
	void SetActiveAttachmentPoints()
	{
		var currentState = player.playerState;
		//Debug.Log("SM : Current Player State1 : " + player.playerState + " currentState = " + currentState);
		if(currentState == Player_Mouse.PlayerState.Holding)
		{
			Stove.transform.GetChild(0).gameObject.SetActive(true);
			Stove.transform.GetChild(1).gameObject.SetActive(true);
			Stove.transform.GetChild(2).gameObject.SetActive(true);
			Stove.transform.GetChild(3).gameObject.SetActive(true);
		} 
		else if(currentState == Player_Mouse.PlayerState.NotHolding)
		{
			Stove.transform.GetChild(0).gameObject.SetActive(false);
			Stove.transform.GetChild(1).gameObject.SetActive(false);
			Stove.transform.GetChild(2).gameObject.SetActive(false);
			Stove.transform.GetChild(3).gameObject.SetActive(false);
		}
		//Debug.Log("SM : Current Player State2 : " + player.playerState + " currentState = " + currentState);
	}
	
	void Update()
	{
		SetActiveAttachmentPoints();
	}
}
