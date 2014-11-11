using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
    public Transform target;
    public float distance = 10f, height = 2f, speed = 3f;

	void Start () {
	
	}
	
	void FixedUpdate () 
    {
        transform.position = Vector3.Lerp(transform.position, target.position - target.forward * distance + target.up * height, Time.deltaTime * speed);

        RaycastHit hit;
        Quaternion dir;
        if (Physics.Raycast(target.position, target.forward, out hit, 100f))
        {
            dir = Quaternion.LookRotation(hit.point - transform.position, target.up);
        }
        else
        {
            dir = Quaternion.LookRotation(target.position + target.forward * 100f - transform.position, target.up);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, dir, Time.deltaTime * 30f);
	}


}
