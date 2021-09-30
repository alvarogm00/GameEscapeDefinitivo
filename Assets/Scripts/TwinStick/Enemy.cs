using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int life = 3;
    public int speed = 3;
    public float stopingDistance = 2;
    GameObject target;
    ManagerTwinStick manager;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindObjectOfType<ManagerTwinStick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) > stopingDistance)
        {
            //Move();
            GetComponent<NavMeshAgent>().destination = target.transform.position;
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            life -= 1;

            if(life <= 0)
            {
                manager.currentPoints++;
                Die();
            }
        }
    }
}
