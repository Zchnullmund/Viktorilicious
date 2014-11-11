using UnityEngine;
using System.Collections;

public class PlayerSteering : MonoBehaviour {
    public float rotationSpeed = 10f, forwardSpeed = 30f, backwardSpeed = 10f;

    Transform body;

	void Start () {
        body = GetComponentInChildren<CapsuleCollider>().transform;
        Screen.showCursor = false;
        Screen.lockCursor = true;
	}

    void FixedUpdate()
    {
        rigidbody.angularVelocity = Vector3.Lerp(rigidbody.angularVelocity,
            transform.TransformDirection(Input.GetAxis("Mouse Y"), 
            Input.GetAxis("Mouse X"), 
            Input.GetAxisRaw("Horizontal") * 5f),
            Time.deltaTime * rotationSpeed);

        Vector3 relVel = transform.InverseTransformDirection(rigidbody.velocity);
        if (Input.GetAxis("Vertical") >= 0f)
            relVel.z = forwardSpeed * Input.GetAxis("Vertical");
        else
            relVel.z = backwardSpeed * Input.GetAxis("Vertical");
        rigidbody.velocity = transform.TransformDirection(relVel);

        body.localEulerAngles = new Vector3(0,0, transform.InverseTransformDirection(rigidbody.angularVelocity).y * -10f);
       
    }
}
