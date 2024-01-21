using UnityEngine;

public class Swimming : MonoBehaviour
{
    // Assuming you've set up the Pico devices to the left and right hands in the inspector
    public Transform leftHand;
    public Transform rightHand;

    private Vector3 previousLeftPosition;
    private Vector3 previousRightPosition;

    private Vector3 leftHandSpeed;
    private Vector3 rightHandSpeed;

    public float speedMultiplier = 1.0f;

    // Variable to check if the player is in water
    private bool isInWater = false;

    void Update()
    {
        // Only execute the swimming logic if the player is in water
        if (isInWater)
        {
            Vector3 leftPosition = leftHand.position;
            Vector3 rightPosition = rightHand.position;

            if (previousLeftPosition != Vector3.zero && previousRightPosition != Vector3.zero)
            {
                leftHandSpeed = (leftPosition - previousLeftPosition) / Time.deltaTime;
                rightHandSpeed = (rightPosition - previousRightPosition) / Time.deltaTime;

                Vector3 averageSpeed = (leftHandSpeed + rightHandSpeed) / 2.0f;

                transform.position += averageSpeed * speedMultiplier * Time.deltaTime;
            }

            previousLeftPosition = leftPosition;
            previousRightPosition = rightPosition;
        }
    }

    // Called when the player enters the water
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
        }
    }

    // Called when the player exits the water
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}
