using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateMachineBehaviour
{
    private Transform m_playerTransform;
    private EnemySimpleStateMachine m_enemyStateMachine;
    private UnityEngine.AI.NavMeshAgent m_agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.isStopped = false;
        m_playerTransform = animator.transform.GetComponent<EnemySimpleStateMachine>().m_player.transform;
        m_enemyStateMachine = animator.transform.GetComponent<EnemySimpleStateMachine>();
    }

    override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_agent.SetDestination(m_playerTransform.position);

        if (m_enemyStateMachine.IsPlayerInAttackRange(m_playerTransform))
        {
            animator.SetTrigger("Attack");
        }

        else
        {
            animator.SetTrigger("Idle");
        }
        //float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransform.position);

        //if(hearingDistance < 8)
        //{
        //    animator.SetTrigger("Attack");
        //}

        //if(hearingDistance > 11)
        //{
        //    animator.SetTrigger("Idle");
        //}

    }
}
