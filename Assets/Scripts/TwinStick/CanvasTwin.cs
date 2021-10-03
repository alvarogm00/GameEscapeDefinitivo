using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTwin : MonoBehaviour
{
    public Text lifeP;
    public Text lifeB;
    public Text CP;
    public Player scriptPlayer;
    public Bouncer scriptBall;
    public ManagerTwinStick manager;

    // Start is called before the first frame update
    void Start()
    {
        //scriptPlayer = FindObjectOfType<Player>();
        //scriptBall = FindObjectOfType<Bouncer>();
        //manager = FindObjectOfType<ManagerTwinStick>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("havuasub");
        lifeB.text = "Ball life: " + scriptBall.life.ToString();
        lifeP.text = "Player life: "+ scriptPlayer.life.ToString();
        CP.text = "Score: "+ manager.currentPoints.ToString();
    }
}
