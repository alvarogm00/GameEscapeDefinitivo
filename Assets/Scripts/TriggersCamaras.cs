using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersCamaras : MonoBehaviour
{

    public Camara camara;

    public bool Shooter;
    public bool TwinStick;
    public bool Platform;

    CheckpointManager checkpointManager;

    // Start is called before the first frame update
    void Start()
    {
        camara = FindObjectOfType<Camara>();

        checkpointManager = FindObjectOfType<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        checkpointManager.currentCheckPoint = this.gameObject;

        if (Shooter == true)
        {
            Debug.Log("heyyy");
            camara.changeTo3 = true;
        }

        if (TwinStick == true)
        {
            camara.changeTo2 = true;
        }

        if (Platform == true)
        {
            camara.changeTo1 = true;
        }
    }
}
