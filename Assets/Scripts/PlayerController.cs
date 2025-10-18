using UnityEngine;

public class PlayerController : MonoBehaviour


{
    private float horizontalInput;
    private float forwardInput;
    private float turnSpeed = 45.0f;
    private float speed = 20.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input boxes
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle foward
        transform.Translate(Vector3.forward * Time.deltaTime * speed* forwardInput);
        // Side to side
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // Proper rotation 
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

    }
}
