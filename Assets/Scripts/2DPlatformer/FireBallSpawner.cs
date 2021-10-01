using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    public float timeToShoot;
    public GameObject fireball;

    float currentTimeToShoot;
    void Start()
    {
        currentTimeToShoot = timeToShoot;
    }

    void Update()
    {
        currentTimeToShoot -= Time.deltaTime;
    }
}
