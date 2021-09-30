using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    float m_playerSpeed;
    float m_verticaleSpeed;
    int m_currentAmmo;
    int m_maxAmmo;
    Animator m_animator;

    void Start()
    {

    }

    void Update()
    {
        if (m_playerSpeed > 0)
        {
            m_animator.SetBool("Walk", true);
        }
        else
        {
            m_animator.SetBool("Walk", false);
        }
    }

    public void SetMovementValues(float horizontalSpeed, float verticalSpeed)
    {
        m_playerSpeed = horizontalSpeed;
        m_verticaleSpeed = verticalSpeed;
    }

    public void SetWeaponValues(int currentAmmo)
    {
        m_currentAmmo = currentAmmo;
    }

    public void Reload()
    {
        if(m_currentAmmo > 0)
        {
            m_animator.SetTrigger("ReloadAmmoLeft");
        }
        else
        {
            m_animator.SetTrigger("ReloadNoAmmo");
        }
    }

    public void Shoot()
    {
        m_animator.SetTrigger("Shoot");
    }
    public void SetAnimator(Animator playerAnim)
    {
        m_animator = playerAnim;
    }
}
