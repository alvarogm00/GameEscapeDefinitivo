using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_movementSpeed;
    public float m_sprintSpeed;
    public float m_jumpForce;
    public int m_maxHealth;

    int m_currentHealth;
    protected float m_speedY;
    protected float m_gravity = -9.81f;

    protected CharacterController m_characterController;
    protected PlayerAnimController m_animController;
    public GameObject[] m_weapons;

    protected virtual void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        m_currentHealth = m_maxHealth;
        m_characterController = GetComponent<CharacterController>();
        m_animController = GetComponent<PlayerAnimController>();
        for (int i = 0; i < m_weapons.Length; i++)
        {
            if(i == 0)
            {
                m_weapons[i].SetActive(true);
            }
            else
            {
                m_weapons[i].SetActive(false);
            }
        }
        SetAnimController(0);
        GameManager.Instance.UpdateHealth(m_currentHealth);
    }

    void Update()
    {
        Move();
        Jump();
        ApplyGravity();
        SwitchWeapon();
    }

    protected virtual void Move()
    {
        float inputZ = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        Vector3 mov = transform.forward * inputZ + transform.right * inputX;
        if (mov.magnitude >= 1) mov.Normalize();
        m_characterController.Move(mov * m_movementSpeed * Time.deltaTime + Vector3.up * m_speedY * Time.deltaTime);

        //m_animController.SetMovementValues(mov.magnitude, m_speedY);
    }
    protected virtual void Jump()
    {
        if (m_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //jumpSound.Play();
            m_speedY = m_jumpForce;
        }
    }

    void ApplyGravity()
    {
        m_speedY += m_gravity * Time.deltaTime;
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < m_weapons.Length; i++)
            {
                if(i == 0)
                {
                    m_weapons[i].SetActive(true);
                    m_weapons[i].GetComponent<SingleBulletWeapon>().UpdateUI();
                    SetAnimController(0);
                }
                else
                {
                    m_weapons[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < m_weapons.Length; i++)
            {
                if (i == 1)
                {
                    m_weapons[i].SetActive(true);
                    SetAnimController(1);
                    m_weapons[i].GetComponent<SingleBulletWeapon>().UpdateUI();
                }
                else
                {
                    m_weapons[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for (int i = 0; i < m_weapons.Length; i++)
            {
                if (i == 2)
                {
                    m_weapons[i].SetActive(true);
                    SetAnimController(2);
                    m_weapons[i].GetComponent<SingleBulletWeapon>().UpdateUI();
                }
                else
                {
                    m_weapons[i].SetActive(false);
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        m_currentHealth -= damage;
        GameManager.Instance.UpdateHealth(m_currentHealth);
        if (m_currentHealth <= 0)
        {
            //GameManager.Instance.SetFinalScorePanel();
        }
    }
    void SetAnimController(int weaponIndex)
    {
        if(m_weapons.Length > 0) 
        {
            //m_animController.SetAnimator(m_weapons[weaponIndex].GetComponent<Animator>());
        }
    }
}
