using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    FPSDoor door;

    private void Start()
    {
        door = FindObjectOfType<FPSDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            door.Close();
            this.gameObject.SetActive(false);
        }
    }
}
