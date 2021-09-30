using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public Camera camara;

    float speed = 5;
    public float rotationSpeed;

    public bool changeTo1;
    public bool changeTo2;
    public bool changeTo3;

    bool thirdPerson;

    // Start is called before the first frame update
    void Start()
    {
        camara.transform.position = pos1.transform.position;
        camara.transform.rotation = pos1.transform.rotation;
        thirdPerson = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(changeTo1 == true)
        {
            changeTo2 = false;
            changeTo3 = false;
            thirdPerson = false;
            Pos1();
        }

        if (changeTo2 == true)
        {
            changeTo1 = false;
            changeTo3 = false;
            thirdPerson = false;
            Pos2();
        }

        if (changeTo3 == true)
        {
            changeTo2 = false;
            changeTo1 = false;
            Pos3();
        }

        if (thirdPerson == true)
        {

            camara.transform.position = pos3.transform.position;
        }
    }

    public void Pos1()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos1.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, pos1.transform.rotation, 1 * Time.deltaTime);

        if (camara.transform.position == pos1.transform.position && camara.transform.rotation == pos1.transform.rotation)
        {
            changeTo1 = false;
            thirdPerson = false;
        }
        

    }

    public void Pos2()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos2.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, pos2.transform.rotation, rotationSpeed * Time.deltaTime);

        if (camara.transform.position == pos2.transform.position && camara.transform.rotation == pos2.transform.rotation)
        {
            changeTo2 = false;
            thirdPerson = false;
        }
    }

    public void Pos3()
    {
        camara.transform.position = Vector3.MoveTowards(camara.transform.position, pos3.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation,pos3.transform.rotation,1* Time.deltaTime);

        if (camara.transform.position == pos3.transform.position && camara.transform.rotation == pos3.transform.rotation)
        {
            changeTo3 = false;
            thirdPerson = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "ToShooter")
    //    {
    //        Debug.Log("heyyy");
    //        Pos3();
    //    }

    //    if (other.tag == "ToTwinStick")
    //    {
    //        Pos2();
    //    }

    //    if (other.tag == "ToPlatform")
    //    {
    //        Pos1();
    //    }
    //}
}
