using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float m_movementSpeed;

    void Update()
    {
        Move();
    }

    public void SetSpeed(float speed)
    {
        m_movementSpeed = speed; 
    }

    private void Move()
    {
        transform.Translate(Vector3.up * m_movementSpeed * Time.deltaTime);
    }
}
