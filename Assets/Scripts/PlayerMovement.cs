using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Playerspeed = 10f;
    [SerializeField] float Gravity = -9.81f;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Playerspeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * Playerspeed * Time.deltaTime; 
        Vector3 Movement = new Vector3(x, 0, z);
        Movement = transform.TransformDirection(Movement); 

        float yVelocity = Gravity * Time.deltaTime;
        Movement.y = yVelocity; 
        characterController.Move(Movement);
    }
}
