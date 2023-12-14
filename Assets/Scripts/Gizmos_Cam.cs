using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmos_Cam : MonoBehaviour
{
	    void OnDrawGizmosSelected()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 0.1F);
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
