using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSC : MonoBehaviour
{
    public Animator characterAnimator;

    Vector2 moveVector;
    public float moveSpeed = 8f;

    private float rotationInput;
    private float rotationSpeed = 10f;

    private bool isJumping;
    private float jumpForce = 10f;
    private float jumpCooldown = 0.5f;
    private float jumpTimer = 0f;

   
    public void InputPlayer(InputAction.CallbackContext _context)
    {
        moveVector = _context.ReadValue<Vector2>();
    }

    public void RotatePlayer(InputAction.CallbackContext _context)
    {
        rotationInput = _context.ReadValue<Vector2>().x;
    }


    private void Update()
    {
        Vector3 movement = new Vector3(moveVector.x, 0, moveVector.y);
        movement.Normalize();
        transform.Translate(moveSpeed * movement * Time.deltaTime);

        float rotationAngle = Mathf.Atan2(moveVector.x, moveVector.y) * Mathf.Rad2Deg;
        transform.GetChild(1).rotation = Quaternion.Euler(0, rotationAngle, 0);
        if (movement.magnitude > 0)
            characterAnimator.SetBool("isWalk", true);
        else
            characterAnimator.SetBool("isWalk", false);

        transform.Rotate(Vector3.forward, rotationInput * rotationSpeed * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void Jump()
    {
        if (!isJumping && Time.time >= jumpTimer)
        {
            isJumping = true;
            characterAnimator.SetTrigger("isJumping");
            jumpTimer = Time.time + jumpCooldown;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
