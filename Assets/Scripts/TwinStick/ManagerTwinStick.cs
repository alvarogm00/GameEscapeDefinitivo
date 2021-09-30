using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class ManagerTwinStick : MonoBehaviour
{
    public int currentPoints = 0;
    public int objectivePointsLvl1 = 5;
    public int objectivePointsLvl2 = 10;

    public Camera camara1;
    public GameObject player1;
    public GameObject ball1;
    public GameObject spawner1;
    public GameObject lvl1;

    public Camera camara2;
    public GameObject player2;
    public GameObject ball2;
    public GameObject spawner2;
    public GameObject lvl2;

    // Start is called before the first frame update
    void Start()
    {
        camara2.enabled=false;
        player2.SetActive(false);
        ball2.SetActive(false);
        spawner2.SetActive(false);
        lvl2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= objectivePointsLvl1 /*&& tpado==false*/)
        {
            camara1.enabled = false;
            player1.SetActive(false);
            ball1.SetActive(false);
            spawner1.SetActive(false);
            lvl1.SetActive(false);

            camara2.enabled = true;
            player2.SetActive(true);
            ball2.SetActive(true);
            spawner2.SetActive(true);
            lvl2.SetActive(true);
        }

        if (currentPoints >= objectivePointsLvl2)
        {
            Debug.Log("win");
        }
    }


}
