using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon info", fileName = "Weapon Info", order = 51)]

public class PlayerWeapon : ScriptableObject
{
	[Header("Stats")]
	[SerializeField]
	private int			m_damage;
	public int damage
    {
        get
        {
			return m_damage;
        }
    }
	[SerializeField]
	private float		m_forceToApply;
	public float forceToApply
    {
        get
        {
			return m_forceToApply;
        }
    }
	[SerializeField]
	private float		m_weaponRange   = 9999.0f;
	public float weaponRange
    {
        get
        {
			return m_weaponRange;
        }
    }
	[SerializeField]
	private float		m_cooldownTime;
	public float cooldownTime
    {
        get
        {
			return m_cooldownTime;
        }
    }
	[SerializeField]
	private int			m_maxAmmo;
	public int maxAmmo
    {
        get
        {
			return m_maxAmmo;
        }
    }
	[SerializeField]
	private float		m_accuracyDropPerShot;
	public float accuracyDropPerShot
    {
        get
        {
			return m_accuracyDropPerShot;
        }
    }
	[SerializeField]
	private float		m_accuracyRecoverPerSecond;
	public float accuracyRecoverPerSecond
    {
        get
        {
			return m_accuracyRecoverPerSecond;
        }
    }
	[SerializeField]
	private float		m_accuracy;
	public float accuracy
    {
        get
        {
			return m_accuracy;
        }
    }
	[SerializeField]
	private int			m_bulletsPerShot;
	public float bulletsPerShot
    {
		get
        {
			return m_bulletsPerShot;
        }
    }
	[SerializeField]
	private bool		m_isMachineGun;
	public bool isMachineGun
    {
        get
        {
			return m_isMachineGun;
        }
    }
	[SerializeField]
	private bool		m_isShotgun;
	public bool isShotgun
    {
        get
        {
			return m_isShotgun;
        }
    }
}
