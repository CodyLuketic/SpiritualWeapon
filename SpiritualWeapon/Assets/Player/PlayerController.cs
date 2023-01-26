using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private float walkingSpeed = 1f;
    [SerializeField]
    private float runningSpeed = 1f;
    [SerializeField]
    private float jumpSpeed = 1f;
    [SerializeField]
    private float gravity = 1f;
    [SerializeField]
    private float lookSpeed = 1f;
    [SerializeField]
    private float lookXLimit = 1f;
    private float rotationX = 0;

    private Vector3 forward;
    private Vector3 right;
    private float curSpeedX = 0;
    private float curSpeedY = 0;
    private float movementDirectionY = 0;
    private bool canMove = true;
    private bool isRunning = false;

    private void Start() {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        Move();
    }
    
    private void Move() {
        forward = transform.TransformDirection(Vector3.forward);
        right = transform.TransformDirection(Vector3.right);
        
        isRunning = Input.GetKey(KeyCode.LeftShift);
        curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded) {
            moveDirection.y = jumpSpeed;
        } else {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded) {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove) {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
