using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    public GameObject fireball;
    public Transform shootingPoint;

    public float timeToShoot;
    public float fireballSpeed;

    public float currentTimeToShoot;
    public bool canShoot = false;

    void Start()
    {
        currentTimeToShoot = timeToShoot;
    }

    void Update()
    {
        if (!canShoot)
            currentTimeToShoot -= Time.deltaTime;

        if (currentTimeToShoot <= 0)
        {
            canShoot = true;
            Shoot();
            currentTimeToShoot = timeToShoot;
        }

    }

    void Shoot()
    {
        if (canShoot)
        {
            GameObject fireballCopy = Instantiate(fireball, shootingPoint.position, Quaternion.identity);

            fireballCopy.GetComponent<Fireball>().SetSpeed(fireballSpeed);
            canShoot = false;
        }
    }
}
