using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    public float movementSpeed = 3.0F;
    public float jumpForce = 10;
    public float gravity = -9.8f;

    protected CharacterController cmpCC;

    protected float speedY = 0;
    protected bool sliding;
    protected bool paused = false;
    protected Vector3 slidingSpeed;

    protected void Awake()
    {
        cmpCC = GetComponent<CharacterController>();
    }

    protected void Update()
    {
        if (!paused)
        {
            ApplyGravity();
            Slide();
            Move();
            CheckFloor();
            Jump();
        }

    }

    protected virtual void Jump()
    {
        if (cmpCC.isGrounded && Input.GetKeyDown(KeyCode.Space) && !sliding)
        {
            speedY = jumpForce;
        }
    }

    protected void CheckFloor()
    {
        if (cmpCC.isGrounded)
        {
            speedY = 0;
        }
    }

    protected void ApplyGravity()
    {
        speedY += gravity * Time.deltaTime;
    }

    protected virtual void Move()
    {
        // Move forward / backward
        float inputZ = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        Vector3 mov = transform.forward * inputZ + transform.right * inputX;
        if (mov.magnitude >= 1) mov.Normalize();


        cmpCC.Move(mov * movementSpeed * Time.deltaTime + Vector3.up * speedY * Time.deltaTime + slidingSpeed * Time.deltaTime);
    }

    protected void Slide()
    {
        sliding = false;
        slidingSpeed = Vector3.zero;

        RaycastHit infoImpacto;
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out infoImpacto, 1))
        {
            Vector3 normalSuperficie = infoImpacto.normal;
            Debug.DrawRay(infoImpacto.point, normalSuperficie, Color.green, 1);
            float angle = Vector3.Angle(normalSuperficie, Vector3.up);
            if (angle > cmpCC.slopeLimit)
            {
                sliding = true;

                slidingSpeed = normalSuperficie;
                slidingSpeed.y = 0;
                slidingSpeed.Normalize();
                slidingSpeed *= movementSpeed;
            }
        }
    }

    public void Pause(bool isPaused)
    {
        paused = isPaused;
    }
}
