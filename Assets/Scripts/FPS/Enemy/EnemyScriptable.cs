using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[CreateAssetMenu(menuName = "New Enemy info", fileName = "Enemy Info", order = 51)]
public class EnemyData : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField]
    private PlayerController m_player;
    public PlayerController player
    {
        get
        {
            return m_player;
        }
    }
    [Header("Components")]
    [SerializeField]
    private Transform m_raycastSpot;
    public Transform raycastSpot
    {
        get
        {
            return m_raycastSpot;
        }
    }
    [SerializeField]
    private Transform m_enemyHead;
    public Transform enemyHead
    {
        get
        {
            return m_enemyHead;
        }
    }
    [SerializeField]
    private Transform[] m_waypointsVector;
    public Transform[] waypointsBVEctor
    {
        get
        {
            return m_waypointsVector;
        }
    }
    [SerializeField]
    private Transform m_lastWaypoint;
    public Transform lastWaypoint
    {
        get
        {
            return m_lastWaypoint;
        }
    }
    [SerializeField]
    private Collider m_collider;
    public Collider collider
    {
        get
        {
            return m_collider;
        }
    }
    [SerializeField]
    private LayerMask ignoreMask;

    [Header("Stats")]
    [SerializeField]
    private int m_health;
    public int health
    {
        get
        {
            return m_health;
        }
    }
    [SerializeField]
    private float m_seeingAngle;
    public float seeingAngle
    {
        get
        {
            return m_seeingAngle;
        }
    }
    [SerializeField]
    private float m_seeingDistance;
    public float seeingDistance
    {
        get
        {
            return m_seeingAngle;
        }
    }
    [SerializeField]
    private float m_attackDistance;
    public float attackDistance
    {
        get
        {
            return m_attackDistance;
        }
    }
    [SerializeField]
    private int m_weaponRange;
    public float weaponRange
    {
        get
        {
            return m_weaponRange;
        }
    }
    [SerializeField]
    private int m_damage;
    public int damage
    {
        get
        {
            return m_damage;
        }
    }
    [SerializeField]
    private float m_cooldownTime = 0.5f;
    public float cooldownTime
    {
        get
        {
            return m_cooldownTime;
        }
    }

    [Header("Visual Effects")]
    [SerializeField]
    private AudioClip m_fireSound;
    [SerializeField]
    private Light m_muzzleLight;
    [SerializeField]
    private ParticleSystem m_muzzleParticles;
    [SerializeField]
    private float m_lightDuration;

    private AudioSource m_shootSound;
    private float m_currentCooldownTime;
    private bool m_canShoot = true;
    void Start()
    {
        m_collider = GetComponent<Collider>();
        m_animator = GetComponent<Animator>();
        m_shootSound = GetComponent<AudioSource>();
        m_player = FindObjectOfType<PlayerController>();

        GameObject[] waypointsVector = GameObject.FindGameObjectsWithTag("Waypoint");
        m_waypointsVector = new Transform[waypointsVector.Length];
        for (int i = 0; i < waypointsVector.Length; i++)
        {
            m_waypointsVector[i] = waypointsVector[i].transform;
        }
        m_lastWaypoint = m_waypointsVector[0];

    }
}

//    public void Update()
//    {
//        if (!m_canShoot)
//        {
//            m_currentCooldownTime -= Time.deltaTime;
//            if (m_currentCooldownTime <= 0)
//            {
//                m_canShoot = true;
//                m_currentCooldownTime = m_cooldownTime;
//            }
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        m_health -= damage;
//        if(m_health <= 0)
//        {
//            m_animator.SetTrigger("Death");
//        }
//    }

//    public bool CanSeePlayer(Transform player)
//    {
//        float angle = Mathf.Abs(Vector3.Angle(m_enemyHead.forward, (player.position - m_enemyHead.position).normalized));

//        if (angle < m_seeingAngle)
//        {
//            return true;
//        }
//        return false;
//    }

//    public bool IsPlayerInAttackRange(Transform player)
//    {
//        float distanceToPlayer = Vector3.Distance(m_enemyHead.position, player.transform.position);

//        if(distanceToPlayer <= m_attackDistance)
//        {
//            return true;
//        }
//        return false;
//    }
//    public void OnIdleAnimCompleted()
//    {
//        m_animator.SetTrigger("Patrol");
//    }
 
//    public void Shoot()
//    {
//        if (m_canShoot)
//        {
//            m_canShoot = false;
//            m_muzzleParticles.Emit(1);
//            StartCoroutine(MuzzleFlashLight());
//            MusicManager.Instance.PlaySound(AppSounds.SHOT2_SFX);
//            m_raycastSpot.LookAt(m_player.transform.position);
//            Ray ray = new Ray(m_raycastSpot.position, m_raycastSpot.forward);
//            Debug.DrawRay(m_raycastSpot.position, m_raycastSpot.forward, Color.green, 10f);
//            RaycastHit hit;

//            if (Physics.Raycast(ray, out hit, m_weaponRange, ~ignoreMask))
//            {
//                print(hit.collider.name);
//                if (hit.collider.GetComponent<PlayerController>())
//                {
//                    hit.collider.GetComponent<PlayerController>().TakeDamage(m_damage);
//                }
//            }
//        }
//    }
//    public void DeathDone()
//    {
//        GameManager.Instance.EnemyKilled(this.gameObject);
//    }

//    private IEnumerator MuzzleFlashLight()
//    {
//        m_muzzleLight.enabled = true;
//        yield return new WaitForSeconds(m_lightDuration);
//        m_muzzleLight.enabled = false;
//    }
//}


