using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            other.GetComponent<PlayerController>().TakeDamage(1000);
        }
    }
}
