using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    public int life = 1;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("hit");
            Destroy(collision.gameObject);
            RecieveDamage();
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    void RecieveDamage()
    {
        life --;
        if(life <= 0)
        {
            Debug.Log("muero");
            Scene escena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(escena.name);
        }
    }
}
