using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour {

    public Transform BulletImpact;
    public Transform Torpedo;
    public float firerate = 0.1f;
    float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer = Mathf.MoveTowards(timer, 0, Time.deltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
           
            GameObject clone = (Instantiate(Torpedo, transform.position - transform.up, transform.rotation) as Transform).gameObject;
            clone.rigidbody.velocity = transform.GetComponentInParent<Rigidbody>().velocity.magnitude * transform.forward + transform.forward;
        }
        if (Input.GetButton("Fire2"))
        {
            if (timer <= 0)
            {
                timer = firerate;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
                {
                    Instantiate(BulletImpact, hit.point, Quaternion.identity);
                };

            }
        }
	}
}
