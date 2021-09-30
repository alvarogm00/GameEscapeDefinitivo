using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletWeapon : MonoBehaviour
{
	[Header("Components")]
	public  Transform		m_raycastSpot;
	public	Light			m_muzzleLight;
	public	ParticleSystem	m_muzzleParticles;

	[Header("Stats")]
	public PlayerWeapon data;

	[Header("Visual Effects")]
	public	float		m_lightDuration;

	private bool		m_canShot = true;
	private bool		m_canReload;
	private bool		m_isReloading;
	private int			m_currentAmmo;
	private float		m_currentCooldownTime;
	private float		m_currentAccuracy;
	
	PlayerAnimController m_animController;

	private void Start()
    {
		m_currentCooldownTime = data.cooldownTime;
		m_currentAmmo = data.maxAmmo;
		m_animController = GetComponentInParent<PlayerAnimController>();
		UpdateUI();
	}
	private void Update()
	{
		m_animController.SetWeaponValues(m_currentAmmo);

        if (m_canShot)
		{
            if (!data.isMachineGun && !data.isShotgun)
            {
				if (Input.GetButtonDown("Fire") && m_currentAmmo > 0 && !m_isReloading)
				{
					Shot();
					m_muzzleParticles.Emit(1);
					StartCoroutine(MuzzleFlashLight());
				}
			}
            else if(data.isMachineGun) 
            {
				if (Input.GetButton("Fire") && m_currentAmmo > 0 && !m_isReloading)
				{
					Shot();
					m_muzzleParticles.Emit(1);
					StartCoroutine(MuzzleFlashLight());
				}
			}

			else if (data.isShotgun)
			{
				if (Input.GetButtonDown("Fire") && m_currentAmmo > 0 && !m_isReloading)
				{
                    for (int i = 0; i < data.bulletsPerShot; i++)
                    {
						Shot();
                    }
					m_currentAmmo--;
					UpdateUI();
					m_muzzleParticles.Emit(1);
					StartCoroutine(MuzzleFlashLight());
				}
			}			
		}

        else if(!m_canShot)
        {
			m_currentCooldownTime -= Time.deltaTime;
			if(m_currentCooldownTime <= 0)
            {
				m_canShot = true;
				m_currentCooldownTime = data.cooldownTime;
            }
        }

		if(Input.GetKeyDown(KeyCode.R) && m_canReload && !m_isReloading)
        {
			Reload();
        }

		CheckAmmo();
		m_currentAccuracy = Mathf.Lerp(m_currentAccuracy, data.accuracy, data.accuracyRecoverPerSecond * Time.deltaTime);
	}

	private void OnGUI()
	{
		Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
		Rect auxRect = new Rect(center.x - 20, center.y - 20, 20, 20);
	}


	private void Shot()
	{
		m_canShot = false;
        if (!data.isShotgun)
        {
			m_currentAmmo--;
			UpdateUI();
		}
		m_animController.Shoot();
		float accuracyModifier = (100 - m_currentAccuracy) / 100;
		Vector3 directionForward = m_raycastSpot.forward;
		directionForward.x += Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.y += Random.Range(-accuracyModifier, accuracyModifier);
		directionForward.z += Random.Range(-accuracyModifier, accuracyModifier);
		m_currentAccuracy -= data.accuracyDropPerShot;

		Ray ray = new Ray(m_raycastSpot.position, directionForward);
		Debug.DrawRay(m_raycastSpot.position, directionForward, Color.green, 1f);
        RaycastHit hit;

		if (Physics.Raycast(ray, out hit, data.weaponRange))
		{
            if (hit.collider.GetComponent<EnemySimpleStateMachine>())
            {
				hit.collider.GetComponent<EnemySimpleStateMachine>().TakeDamage(data.damage);
			}
		}

		MusicManager.Instance.PlaySound(AppSounds.SHOT1_SFX);
	}

	private void CheckAmmo()
    {
		if(m_currentAmmo < data.maxAmmo)
        {
			m_canReload = true;
        }

		if(m_currentAmmo <= 0)
        {
			m_canShot = false;
        }
    }

	private void Reload()
    {
		m_canShot = false;
		m_isReloading = true;
		m_animController.Reload();
		m_currentAmmo = data.maxAmmo;
		UpdateUI();
    }

	public void OnReloadFinish()
    {
		m_canShot = true;
		m_canReload = false;
		m_isReloading = false;
    }

	private IEnumerator MuzzleFlashLight()
	{
		m_muzzleLight.enabled = true;
		yield return new WaitForSeconds(m_lightDuration);
		m_muzzleLight.enabled = false;
	}

	public void UpdateUI()
    {
		GameManager.Instance.UpdateAmmo(m_currentAmmo, data.maxAmmo);
    }
}
