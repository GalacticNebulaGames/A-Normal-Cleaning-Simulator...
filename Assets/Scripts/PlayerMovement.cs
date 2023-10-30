using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   void Start()
   {
    Cursor.lockState = CursorLockMode.Locked;  
   }




    [Range(0, 10)]
    public float speed;
    [Range(1, 100)]
    public float rotationSpeed; // Adjust the rotation speed as needed

    private float rotationX = 0f;

    private void Update()
    {
        // Move forward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            var forward = transform.forward; 
            forward.y = 0; 
            forward.Normalize();
            transform.position += forward * speed * Time.deltaTime;


        }

        // Rotate with the mouse input
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float verticalRotation = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; // Negate for correct vertical rotation

        // Rotate the player around the Y-axis
        transform.Rotate(0, horizontalRotation, 0);

        // Rotate the player vertically and clamp the angle
        rotationX += verticalRotation;
        rotationX = Mathf.Clamp(rotationX, -90, 90); // Limit vertical rotation to -90 to 90 degrees
        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y, 0);
    }
}
