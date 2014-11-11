using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour
{
    public GameObject explosion;
    public float radius = 10;
    public float power = 1000;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            if (hit && hit.rigidbody)
                hit.rigidbody.AddExplosionForce(power, transform.position, radius, 3.0F);

        }
        Destroy(gameObject);
    }
}
