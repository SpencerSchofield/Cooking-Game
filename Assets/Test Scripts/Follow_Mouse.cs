using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Follow_Mouse : MonoBehaviour
{
		public int frame;



	IEnumerator Example()
	{
		Debug.Log("Waiting for princess to be rescued...");
		yield return new WaitUntil(() => frame >= 10);
		Debug.Log("Princess was rescued!");
	}


	/*
	Want a function within moveable objects that follow the mouse after only 1 click. not sure how i'll active the follow method as my previous
	attempt did work but only if a raycast was constantly hiting the moveable object and if i was holding the left mouse button down. I want it 
	to work as; I click the object, object follows player mouse, I click again and the object stops following the mouse (I will later have it return to it original position).
	*/
	/*
	This script should be applied to all moveable objects.
	*/
	
	Rigidbody rb;
	public bool isFollowing = true;
	void Start()
	{
		rb =  gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
		rb.useGravity = false;
		isFollowing = true;
		StartCoroutine(Example());
		StartCoroutine(Follow());
	}
	
	public void FollowPlayer()
	{
		StartCoroutine(Follow());
	}
	
	
	int ten = 10;
	public IEnumerator Follow()
	{
		if(isFollowing)
		{
			
			rb.position = new Vector3 (ten,ten,ten);
			ten *= 2;
		}
		Debug.Log("Follow Coord : " + ten);
		yield return new WaitUntil(()=> ten >= 100);
	}

	// Update is called once per frame
	void Update()
	{
		if(ten <= 100)
		{
			Debug.Log("Ten : " + ten);
			ten*=2;
		}
				if (frame <= 10)
		{
			Debug.Log("Frame: " + frame);
			frame++;
		}
	}
	
	private void FixedUpdate() 
	{
		
	}
}
