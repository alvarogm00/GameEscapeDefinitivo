using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public Camera camara;

    public Transform player;

    public Player controlTwin;
    public Player2DMovement controlPlatform;
    public PlayerController controlShooter;

    public MouseLook rotShooter;
    public Rotation rotTwin;
    public Weapon weaponTwin;
    public Canvas canvasPlatform;

    float speed = 5;
    public float rotationSpeed;

    public bool changeTo1;
    public bool changeTo2;
    public bool changeTo3;

    bool thirdPerson;
    bool platform;

    // Start is called before the first frame update
    void Start()
    {
        camara.transform.position = pos3.transform.position;
        camara.transform.rotation = pos3.transform.rotation;
        thirdPerson = true;
        platform = false;

        controlTwin.enabled = false;
        controlPlatform.enabled = false;
        controlShooter = FindObjectOfType<PlayerController>();
        controlShooter.enabled = true;
        rotShooter.enabled = true;
        rotTwin.enabled = false;
        weaponTwin.enabled = false;
        canvasPlatform.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        ToShooter();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeTo1 == true)
        {
            changeTo2 = false;
            changeTo3 = false;
            thirdPerson = false;
            controlTwin.enabled = false;
            controlPlatform.enabled = false;
            controlShooter.enabled = false;
            rotShooter.enabled = false;
            rotTwin.enabled = false;
            weaponTwin.enabled = false;
            canvasPlatform.enabled = true;

            player.rotation = Quaternion.Euler(0,90,0);

            ToPlatform();
        }

        if (changeTo2 == true)
        {
            changeTo1 = false;
            changeTo3 = false;
            thirdPerson = false;

            platform = false;

            controlTwin.enabled = false;
            controlPlatform.enabled = false;
            controlShooter.enabled = false;
            rotShooter.enabled = false;
            rotTwin.enabled = true;
            weaponTwin.enabled = true;
            canvasPlatform.enabled = false;

            player.rotation = Quaternion.Euler(0, 90, 0);

            ToTwinstick();
        }

        if (changeTo3 == true)
        {
            changeTo2 = false;
            changeTo1 = false;
            platform = false;

            controlTwin.enabled = false;
            controlPlatform.enabled = false;
            controlShooter.enabled = false;
            rotTwin.enabled = false;
            weaponTwin.enabled = false;
            canvasPlatform.enabled = false;

            ToShooter();
        }

        if (thirdPerson == true)
        {
            camara.transform.position = pos3.transform.position;
        }
        if (platform == true)
        {
            camara.transform.position = pos1.transform.position;
        }
    }

    public void ToPlatform()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos1.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, pos1.transform.rotation, 1 * Time.deltaTime);
        camara.transform.SetParent(null);

        if (camara.transform.position == pos1.transform.position && camara.transform.rotation == pos1.transform.rotation)
        {
            controlPlatform.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            changeTo1 = false;
            thirdPerson = false;
            platform = true;
        }


    }

    public void ToTwinstick()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos2.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, pos2.transform.rotation, rotationSpeed * Time.deltaTime);
        camara.transform.SetParent(null);


        if (camara.transform.position == pos2.transform.position && camara.transform.rotation == pos2.transform.rotation)
        {
            controlTwin.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            changeTo2 = false;
            thirdPerson = false;
            platform = false;
        }
    }

    public void ToShooter()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos3.transform.position, speed * Time.deltaTime);
        camara.transform.SetParent(player);

        transform.rotation = Quaternion.Lerp(transform.rotation, pos3.transform.rotation, 1 * Time.deltaTime);

        if (camara.transform.position == pos3.transform.position && camara.transform.rotation == pos3.transform.rotation)
        {
            controlShooter.enabled = true;
            rotShooter.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            changeTo3 = false;
            thirdPerson = true;
            platform = false;
        }
    }
}
