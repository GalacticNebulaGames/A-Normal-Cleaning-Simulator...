using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10)]
    public float speed;

    [Range(1, 100)]
    public float rotationSpeed; // Adjust the rotation speed as needed

    private float rotationX = 0f;
    private bool isSprinting = false;
    private float sprintSpeedMultiplier = 2f;
    private float stamina = 15f;
    private float staminaMax = 45f;
    private float staminaTimer = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Move forward
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (!isSprinting || stamina > 0))
        {
            var forward = transform.forward;
            forward.y = 0;
            forward.Normalize();
            float currentSpeed = isSprinting ? speed * sprintSpeedMultiplier : speed;
            transform.position += forward * currentSpeed * Time.deltaTime;

            if (isSprinting)
            {
                stamina -= Time.deltaTime;
                if (stamina <= 0)
                {
                    isSprinting = false;
                    stamina = 0f;
                    staminaTimer = staminaMax;
                }
            }
        }

        // Move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var left = -transform.right;
            left.y = 0;
            left.Normalize();
            transform.position += left * speed * Time.deltaTime;
        }

        // Rotate with the mouse input
        float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float verticalRotation = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Rotate the player around the Y-axis
        transform.Rotate(0, horizontalRotation, 0);

        // Rotate the player vertically and clamp the angle
        rotationX += verticalRotation;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y, 0);

        // Sprinting controls
        if (Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            if (!isSprinting && stamina > 0)
            {
                isSprinting = true;
            }
        }

        // Stamina regeneration
        if (!isSprinting && stamina < staminaMax)
        {
            staminaTimer += Time.deltaTime;
            if (staminaTimer >= staminaMax)
            {
                stamina += Time.deltaTime;
                stamina = Mathf.Clamp(stamina, 0, staminaMax);
            }
        }
    }
}