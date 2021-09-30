using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsPositionCollider : MonoBehaviour
{
    Player2DMovement player;
    void Start()
    {
        player = FindObjectOfType<Player2DMovement>();

        CorrectX();
    }

    void CorrectX()
    {
        Vector3 correctPos = this.transform.position;
        correctPos.x = player.transform.position.x;
        this.transform.position = correctPos;
    }
}
