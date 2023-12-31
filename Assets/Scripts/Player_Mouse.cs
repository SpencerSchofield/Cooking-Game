using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class Player_Mouse : MonoBehaviour
{
	//public Camera camera;
	//if raycast hit, start follow coroutine, disable other objects being able to be picked up as well, maybe remove and rigibody/collider and add it back
	bool isHolding;
	GameObject holdMe;
	[SerializeField] FirePitHandler2 FPH;
	[SerializeField] SceneManager SM;
	[SerializeField] GameObject FishPrefab;
	[SerializeField] GameObject MeatPrefab;
	[SerializeField] GameObject MushroomPrefab;
	
	/*!! Set firepit collider to be just slightly bigger then what it is so when I place an object on it it can detect it
	Also will need a FoodType script that holds name cookTime and particle effect system when cooking and fully cooked.
	*/
	Coroutine inst = null;
	public static event Action OnKnifeHeld; //activate any cPoints on any food type on scene.
	public static event Action OnObjectHit;
	private IEnumerator ObjectFollowMouse(GameObject obj)
	{
		if (playerState == PlayerState.Holding || playerState == PlayerState.UsingKnife)
		{
			/*
			Make a function that pushes the object im holding in front of a object its behind. 
			*/
			RaycastHit hitT;
			Ray rayT = Camera.main.ScreenPointToRay(Input.mousePosition);
			bool testRay = Physics.Raycast(rayT, out hitT, 10.0f);
			Debug.Log("testRay : " + testRay);
			obj.layer = LayerMask.NameToLayer("Ignore Raycast");
			if(testRay)
			{
				obj.GetComponent<Rigidbody>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (-hitT.collider.bounds.max.normalized.z)));
			} else
			{
				obj.GetComponent<Rigidbody>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z+12));
			}
			
			if (Input.GetMouseButtonDown(1))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				//fire raycast
				Physics.Raycast(ray, out hit);
				Debug.Log(hit.transform.tag);
				CheckTag(hit, obj);//returns the tag of the object I hit

			}

		yield return new WaitUntil(() => !isHolding);

		}


	}

	public PlayerState playerState;
	/*
	*/
	public enum PlayerState
	{
		NotHolding,
		Holding,
		UsingKnife
	}
	void GetPlayerState()
	{
		
	}

	void Action()//Unity Actions / Delegates..come back when understand more might even need to remove and come up with better implement or atleast one that works
	{
		holdMe.transform.position = new Vector3(0, 0, 0);
	}

	/*
	PickUpObjects() is called every frame. Shoots raycast when the player left clicks and checks if the object they hit can be moved. if so it sets it to the holdMe
	GameObject and starts the ObjectFollowMouse coroutine. Can expand the code to compare the tag to other game objects which the play may not need to move but can 
	interact with (in that case i'd need to rename the function to better explain the method but for now this is fine).
	*/
	/*
	This whole function needs redoing, and to make better use of the PlayerState machine., Might need to have this inside of a FixedUpdate also (This should be my
	main focus to get back on track with the game, most of my game revoles around this funciton to pickup objects)
	*/
	public void PickUpObject()
	{
		//Debug.Log(holdMe);
		if (playerState == PlayerState.NotHolding && Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//fire raycast
			Physics.Raycast(ray, out hit);
			if (hit.rigidbody.CompareTag("FoodType"))
			{
				holdMe = hit.rigidbody.gameObject;
				playerState = PlayerState.Holding;
				//previousLocation = holdMe.position;
			} 
			else if(hit.rigidbody.CompareTag("Knife"))
			{
				holdMe = hit.rigidbody.gameObject;
				playerState = PlayerState.UsingKnife;
				Actions.OnKnifeHeld();
			}
			else if (hit.rigidbody.CompareTag("SpawnFish"))
			{
				GameObject spawnItem = Instantiate(FishPrefab);
				holdMe = spawnItem;
				playerState = PlayerState.Holding;
			} 
			else if(hit.rigidbody.CompareTag("SpawnMushroom"))
			{
				GameObject spawnItem = Instantiate(MushroomPrefab);
				holdMe = spawnItem;
				playerState = PlayerState.Holding;
			} 
			else if(hit.rigidbody.CompareTag("SpawnMeat"))
			{
				GameObject spawnItem = Instantiate(MeatPrefab);
				holdMe = spawnItem;
				playerState = PlayerState.Holding;
			}
			else return;
		}

		if (!holdMe) return;
		else if (holdMe)
		{
			//playerState = PlayerState.Holding;//removes playerstate using knife on line 111;
			isHolding = true;
			inst = StartCoroutine(ObjectFollowMouse(holdMe));
		}

	}

	/*
	DropObject() is called every frame. Will stop whatever object is currently being held by the player (mouse) by setting the holdMe GameObject to null.
	I can also use a previousLocation which returns the object to wherever it was picked up from, can improve this by have the objects I pick up remember their 
	home location and return there when I drop the item.
	*/
	public Vector3 previousLocation;
	public void DropObject()
	{
		if (Input.GetMouseButton(1))
		{
			//holdMe.position = previousLocation;
			if (!holdMe) return;
			playerState = PlayerState.NotHolding;
			isHolding = false;
			holdMe.layer = LayerMask.NameToLayer("Default");//Set Layermask back to default after letting go.
			holdMe = null; //Set holdMe to false is only way to get object to stop following mouse.
			StopCoroutine(inst);
			//This is need to change when I add new coroutines but this is the only way to stop the ObjectFollowsMouse function.
		}
	}

	/*
	CheckTag(Raycast, GameObect) is called within the ObjectFollowsMouse coroutine. This function checks the tag of the object it hits, depending on the tag 
	depends on what happens to the GameObject obj(current obj the player is holding).
	*/
	void CheckTag(RaycastHit hit, GameObject obj)
	{
		var taggedAs = hit.transform.tag;
		if (taggedAs == "Untagged")
		{
			Debug.Log("Object is Untagged");

		}
		else if (taggedAs == "Interactable")
		{
			FPH.CheckCanPlaceObject(() => Action());

			//do Something
		}
		else if (taggedAs == "Bin")
		{
			Destroy(obj);

		}
		else if (taggedAs == "FirePit")
		{
			FPH.CheckCanPlaceOBJ(obj);

		}
		else if (taggedAs == "FireSlot")
		{
			obj.transform.position = hit.rigidbody.position;
		}
		else if (taggedAs == "Knife")
		{
				
		}
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		PickUpObject();
		DropObject();
	}
	

}

