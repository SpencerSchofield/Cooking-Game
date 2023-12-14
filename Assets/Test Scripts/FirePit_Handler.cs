using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FirePit_Handler : MonoBehaviour
{
	delegate void PlaceObject(GameObject obj);
	PlaceObject placeObject;
	GameObject _aPoint;
	public void HoldObject(GameObject obj)
	{
		Debug.Log("Running Delegate");
		//get attachment points
		_aPoint = GameObject.Find("FirePit").transform.GetChild(0).gameObject;
		bool isSlot1Free = true;
		if(_aPoint && isSlot1Free)
		{
			obj.transform.position = _aPoint.transform.position;
			isSlot1Free = false;
		}
	}
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
