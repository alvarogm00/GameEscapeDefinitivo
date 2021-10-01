using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSKey : MonoBehaviour
{
    GameManager m_gameManager;

    private void Start()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            m_gameManager.AddFPSKeys();
            this.gameObject.SetActive(false);
        }
    }
}
