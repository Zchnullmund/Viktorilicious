using UnityEngine;
using System.Collections;

public class LaserSight : MonoBehaviour {
    LineRenderer line;
    Light light;
    public float length;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        light = transform.GetComponentInChildren<Light>();
        light.enabled = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward * length);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000f))
        {
            light.transform.position = hit.point + hit.normal;
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
	}
}
