using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject shootPoint;
    public GameObject player;
    Player playerScript;

    public float VelocidadRot = 100;
    public float timeBetweenShoots = 0.05f;
    public float timeGlobal = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShoots = 0f;
        playerScript = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenShoots -=  Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerScript.descontrolado == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, shootPoint.transform.position, shootPoint.transform.rotation);
    }

    public void CrazyShoot()
    {
        this.gameObject.transform.RotateAround(player.transform.position, Vector3.up, VelocidadRot * Time.deltaTime);
        if(timeBetweenShoots <= 0)
        {
            Instantiate(Bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            timeBetweenShoots = 0.05f;
        }
    }
}
