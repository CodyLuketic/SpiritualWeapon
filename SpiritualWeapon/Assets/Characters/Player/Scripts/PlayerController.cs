using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController characterController = null;
    [SerializeField] private Animator animator = null;

    [Header("Movement")]
    [SerializeField] private float walkingSpeed = 1f;
    [SerializeField] private float runningSpeed = 1f;
    [SerializeField] private float gravity = 1f;
    private float currentSpeedX = 0, currentSpeedY = 0, movementDirectionY = 0;

    private Vector3 moveDirection = Vector3.zero;

    private bool canMove = true, canRotate = true, isRunning = false;

    private void Update() {
        Move();

        if(canRotate) {
            Rotate();
        }
    }
    
    private void Move() {  
        isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        currentSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        movementDirectionY = moveDirection.y;
        
        moveDirection = (Vector3.forward * currentSpeedX) + (Vector3.right * currentSpeedY);

        if(!characterController.isGrounded) {
            movementDirectionY -= gravity * Time.deltaTime;
        }
        moveDirection.y = movementDirectionY;

        if(moveDirection.x != 0 || moveDirection.z != 0) {
            animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Rotate() {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
         
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) + 90;
 
        transform.rotation = Quaternion.Euler (new Vector3(0, -angle, 0));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void SetCanRotate(bool can) {
        SetCanRotateHelper(can);
    }
    private void SetCanRotateHelper(bool can) {
        canRotate = can;
    }
}
