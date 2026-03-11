using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float floatAmplitude = 0.25f;   // How high the coin floats
    public float floatFrequency = 2f;      // Speed of floating
    public float rotationSpeed = 90f;      // Degrees per second

     private Vector3 startPos;
     private float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, 2f * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
         // Floating motion
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // // Rotation
        // transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
