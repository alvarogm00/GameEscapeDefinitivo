using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public GameObject currentCheckPoint;
    public CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        //currentCheckPoint.transform.position = player.position;
        //currentCheckPoint.rotation = player.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            player.transform.position = currentCheckPoint.transform.position;
            player.transform.rotation = currentCheckPoint.transform.rotation;
        }
    }

    public void ChangeCurrent()
    {

    }
}
