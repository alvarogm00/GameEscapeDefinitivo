using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    private Transform m_playerTransform;
    private EnemySimpleStateMachine m_enemyStateMachine;
    private UnityEngine.AI.NavMeshAgent m_agent;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_playerTransform = animator.transform.GetComponent<EnemySimpleStateMachine>().m_player.transform;

        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_enemyStateMachine = animator.transform.GetComponent<EnemySimpleStateMachine>();

        SetRandomWayPoint();
    }

    override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransform.position);

        if (m_enemyStateMachine.CanSeePlayer(m_playerTransform))
        {
            animator.SetTrigger("Chase");
        }

        if (!m_agent.pathPending && m_agent.remainingDistance < 1)
        {
            animator.SetTrigger("Idle");
        }
    }

    private void SetRandomWayPoint()
    {
        Transform randomWaypoint = m_enemyStateMachine.m_waypointsVector[Random.Range(0, m_enemyStateMachine.m_waypointsVector.Length)];

        //if(m_enemyStateMachine.m_lastWaypoint == null)
        //{
        //    m_agent.isStopped = false;
        //    m_agent.SetDestination(randomWaypoint.position);
        //    m_enemyStateMachine.m_lastWaypoint.position = randomWaypoint.position;
        //}

        if (randomWaypoint.position != m_enemyStateMachine.m_lastWaypoint.position)
        {
            m_agent.isStopped = false;
            m_agent.SetDestination(randomWaypoint.position);
            m_enemyStateMachine.m_lastWaypoint.position = randomWaypoint.position;
        }
        else
        {
            SetRandomWayPoint();
        }
    }
}
