using UnityEngine;

public class SunMovement : MonoBehaviour
{
    public float rotationSpeed = 1.0f; // Adjust the speed of the sun's movement

    void Update()
    {
        // Rotate the Directional Light (sun) slowly over time
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
}
