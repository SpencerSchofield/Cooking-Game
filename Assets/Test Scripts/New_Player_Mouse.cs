using UnityEngine;

public class New_Player_Mouse : MonoBehaviour
{

	Rigidbody rb;
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//fire raycast
			if (Physics.Raycast(ray, out hit))
			{
				rb = hit.rigidbody;
				if (rb != null && rb.CompareTag("Moveable"))
				{
					
					Vector3 mousePosition = Input.mousePosition;
					Debug.Log(mousePosition);
					mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -10));
					rb.position = Vector3.Lerp(rb.position,mousePosition,0.1f);
					
					//rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
				}
			}
		}
		void FixedUpdate()
		{

		}
	}
}
