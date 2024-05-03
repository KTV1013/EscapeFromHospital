using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable
{
    [SerializeField] protected float force = 100f;
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
            body.AddForce(force * transform.forward);
        }
    }
}
