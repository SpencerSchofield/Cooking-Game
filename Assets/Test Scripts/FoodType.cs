using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodType : MonoBehaviour
{
	float CookTime;
	bool isCooked;
	ParticleSystem particleSystem;

	void Start()
	{
		CookTime = 5f;
		StartCoroutine(CountDownCooker());
	}
	
	string GetName()
	{
		return name;
	}
	
	void SetCookingTime(float cookingTime)
	{
		this.CookTime = cookingTime;
	}
	
	float GetCookingTime()
	{
		return CookTime;
	}
	
	IEnumerator CountDownCooker()
	{
		while(isCooked == false)
		{
			CookTime -= 1f;
			if (CookTime <= 0f)
			{
				isCooked = true;
				Debug.Log("Timer Ended");
				yield return null;
			}
			
			if(isCooked == true)//this might not get called but as long as isCooked turns true I can get other functions to run instead
			{
				Debug.Log("item is cooked");
				yield return null;
			}
			Debug.Log(isCooked);
			yield return new WaitForSeconds(1f);
		}
	}
	
	//Need to timer coroutine to tick down the cooktime
	//Start cooking if within FirePit collider
	
}
