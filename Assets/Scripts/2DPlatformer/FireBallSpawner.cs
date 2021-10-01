using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{    
    public GameObject fireball;
    public Transform shootingPoint;

    public float timeToShoot;
    public float fireballSpeed;

    float currentTimeToShoot;
    bool canShoot = true;

    void Start()
    {
        currentTimeToShoot = timeToShoot;
    }

    void Update()
    {
        currentTimeToShoot -= Time.deltaTime;

        if(currentTimeToShoot <= 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject fireballCopy = Instantiate(fireball, shootingPoint.position, Quaternion.identity);

        fireballCopy.GetComponent<Fireball>().SetSpeed(fireballSpeed);
    }
}
