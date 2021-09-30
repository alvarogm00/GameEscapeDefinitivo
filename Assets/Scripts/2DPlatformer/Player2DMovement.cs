using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DMovement : PlayerController
{
    [SerializeField] bool canJump;
    [SerializeField] bool canRight;
    [SerializeField] bool canLeft;
    bool canMove;

    protected override void Start()
    {
        base.Start();
        Cursor.lockState = CursorLockMode.None;

    }
    public void checkLeftButton(bool left)
    {
        canLeft = left;
    }
    public void checkRightButton(bool right)
    {
        canRight = right;
    }
    public void checkJumpButton(bool jump)
    {
        canJump = jump;
    }
    protected override void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        if(inputX > 0 && !canRight)
        {
            canMove = false;
        }
        else if(inputX < 0 && !canLeft)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (canMove)
        {
            Vector3 mov = transform.forward * inputX;
            if (mov.magnitude >= 1) mov.Normalize();


            m_characterController.Move(mov * m_movementSpeed * Time.deltaTime + Vector3.up * m_speedY
                * Time.deltaTime);// + slidingSpeed * Time.deltaTime);
        }
    }

    protected override void Jump()
    {
        if (canJump)
        {
            base.Jump();
        }       
    }
}
