using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopFood : MonoBehaviour
{
	GameObject food;
	GameObject cPoint1;
	GameObject cPoint2;
	GameObject Body;
	GameObject Head;
	GameObject Tail;
	void Start()
	{
		food = GameObject.Find("Fish").transform.gameObject;
		cPoint1 = food.transform.GetChild(0).transform.gameObject;
		cPoint2 = food.transform.GetChild(1).transform.gameObject;
		Body = food.transform.GetChild(2).transform.gameObject;
		Head = food.transform.GetChild(3).transform.gameObject;
		Tail = food.transform.GetChild(4).transform.gameObject;;
	}
	
	void CutFood()
	{
		if(Input.GetKeyDown("space"))
		{
			Debug.Log("CutFood");
			Head.transform.parent = null;
			food.GetComponent<Collider>().gameObject.SetActive(false);
			food.GetComponent<Collider>().gameObject.SetActive(true);
			//Head.GetComponent<Collider>(); //set active
		}
	}
	
	void Update()
	{
		CutFood();
	}
	
	
	

}
