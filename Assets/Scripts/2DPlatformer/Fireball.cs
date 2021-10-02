using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    float m_movementSpeed;
    public int m_damage;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().TakeDamage(m_damage);
        }

        this.gameObject.SetActive(false);
    }
}
