using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class FirePitHandler2 : MonoBehaviour
{
	private Action ActionCallBack;
	Dictionary<GameObject, bool> list;
	public List<KeyValuePair<GameObject,bool>> attachmentPoints;//make into class to display in editor
	
	GameObject _aPoint;
	GameObject _aPoint2;
	bool isSlot1Free = true;
	bool isSlot2Free = true;
	
	// Start is called before the first frame update
	void Start()
	{
		List<KeyValuePair<GameObject,bool>> attachmentPoints = new List<KeyValuePair<GameObject,bool>>();
		GameObject Hopeful = GameObject.Find("FirePit").transform.GetChild(0).gameObject;
		
		attachmentPoints.Add(new KeyValuePair<GameObject,bool>(Hopeful, true));
		attachmentPoints.Add(new KeyValuePair<GameObject, bool>(GameObject.Find("FirePit").transform.GetChild(1).gameObject, true));
		attachmentPoints.Add(new KeyValuePair<GameObject, bool>(GameObject.Find("FirePit").transform.GetChild(2).gameObject, true));
		attachmentPoints.Add(new KeyValuePair<GameObject, bool>(GameObject.Find("FirePit").transform.GetChild(3).gameObject, true));
		attachmentPoints.Add(new KeyValuePair<GameObject, bool>(GameObject.Find("FirePit").transform.GetChild(4).gameObject, true));
	}
	public void CheckCanPlaceObject(Action actionCallBack)//change function name to placeobject or something that makes more sense, hold object get me confused with the mouse holding the object
	{
		
		
		
		Debug.Log("Running Delegate");
		
		//get attachment point
		_aPoint2 = GameObject.Find("FirePit").transform.GetChild(1).gameObject;
		this.ActionCallBack = actionCallBack;
		
		
		if(_aPoint && isSlot1Free)
		{
			isSlot1Free = false;
			actionCallBack();
			/*My callback?
			obj.transform.position = _aPoint.transform.position;
			*/
			
		}else if(_aPoint2 && isSlot2Free)
		{
			actionCallBack();
		}
	}
	public void CheckCanPlaceOBJ(GameObject obj)
	{
		//Check list for avaiable attachmentpoints
		//if there are then place object at the position
		//if not then return a Debug.Log for now
		bool isEmpty = !attachmentPoints.Any();
		if(isEmpty)
		{
			Debug.Log("Attachment Points are null");
		}
		if(attachmentPoints[0].Value.Equals(true))
		{
			Debug.Log("It Works");
			obj.transform.position = attachmentPoints[0].Key.transform.position;
		} else
		{
			Debug.Log("Did not place obj in position");
		}
		
	}
	
}
