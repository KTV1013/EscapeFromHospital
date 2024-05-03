using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable
{
    [SerializeField] protected Vector3 localForce = new(0, 0, -40);
    Rigidbody body;
    bool isPushing = false;
    public override void EndInteraction()
    {
        isPushing = false;
    }

    public override void StartInteraction()
    {
        isPushing = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPushing) 
        {
            Vector3 direction = transform.forward * localForce.z;
            direction += transform.right * localForce.x;
            direction += transform.up * localForce.y;
            body.AddForce(direction);
        }
    }
}
