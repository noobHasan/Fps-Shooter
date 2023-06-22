using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AnimationController thisAnim;

    private float moveSpeed = 5;
    public Joystick joystick;
    private Quaternion targetRotation;
    private float rotateSpeed = 40f;
    public bool canMove;
    private bool isMoving;

    public bool isFiring;
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            Vector3 moveDir = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);

            if (moveDir != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);



                if (!isFiring)
                {
                    transform.position = new Vector3(transform.position.x + horizontalInput * moveSpeed * Time.deltaTime, transform.position.y,
                        transform.position.z + verticalInput * moveSpeed * Time.deltaTime);
                    thisAnim.currentAnimState = 1;
                }
                else
                {
                    thisAnim.currentAnimState = 2;
                }

                isMoving = true;
            }
            else
            {
                if (isMoving)
                {
                    thisAnim.currentAnimState = 0;
                    isMoving = false;
                }
            }
        }
    }
}
