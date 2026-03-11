using UnityEngine;

public class PlayerController : MonoBehaviour


{
    private float horizontalInput;
    private float forwardInput;
    private float turnSpeed = 45.0f;
    private float speed = 20.0f;
    public GameObject sparklePrefab;
    public GameObject collisionPrefab;
    public AudioSource coinAudio;
    public AudioSource hitSound;
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
    void OnTriggerEnter(Collider other) 
        {
    // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("Pickup")) 
            {
    // Deactivate the collided object (making it disappear).
                other.gameObject.SetActive(false);
                // Show Particle Effect
                GameObject myPrefab = Instantiate(sparklePrefab);
                myPrefab.transform.position = other.transform.position;
                
                // Play Sound Effect
                coinAudio.Play();
            }

        else if (other. gameObject.CompareTag("Obstacle"))
            {
                if (collisionPrefab != null)
                    {
                        GameObject myPrefab = Instantiate(collisionPrefab);
                        myPrefab.transform.position = other.transform.position;
                    }
                    
                hitSound.Play();
            }
        
    }
}