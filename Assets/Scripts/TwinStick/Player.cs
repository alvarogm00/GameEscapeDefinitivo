using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CharacterController cmpCC;
    public Weapon weapon;

    public float VelocidadMov = 10;
    public bool descontrolado = false;

    public float tiempoDescontrolado = 1f;
    public float tiempoBase = 1f;

    public int life = 5;

    // Start is called before the first frame update
    void Start()
    {
        cmpCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (life <= 0)
        {
            Descontrol();
        }

        if (descontrolado == true)
        {
            tiempoDescontrolado -= Time.deltaTime;
            weapon.CrazyShoot();           
        }

        else if(descontrolado == false)
        {
            Mover();
        }

        
        if (tiempoDescontrolado <= 0)
        {
            descontrolado = false;
            tiempoDescontrolado = tiempoBase;
            life = 5;
        }
    }

    private void Mover()
    {
        float inputZ = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        Vector3 mov = transform.forward * inputZ + transform.right * inputX;

        if (mov.magnitude > 1)
        {
            mov.Normalize();
        }


        cmpCC.Move(mov * VelocidadMov * Time.deltaTime);
    }

    public void RecieveDamage()
    {
        life -= 1;
        
    }

    void Descontrol()
    {
        descontrolado = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Enemy")
        {
            RecieveDamage();
            Destroy(other.gameObject);
        }
    }
}
