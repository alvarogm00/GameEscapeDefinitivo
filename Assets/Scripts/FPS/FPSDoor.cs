using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDoor : MonoBehaviour
{
    Animator m_anim;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    public void Open()
    {
        m_anim.SetTrigger("Open");
    }

    public void Close()
    {
        m_anim.SetTrigger("Close");
    }

}
