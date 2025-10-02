using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves the camera based on player input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed *  Time.deltaTime);
    }
}
