using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Transform m_playerTransform;
    private UnityEngine.AI.NavMeshAgent m_agent;
    private EnemySimpleStateMachine m_enemyStateMachine;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_playerTransform = animator.transform.GetComponent<EnemySimpleStateMachine>().m_player.transform;
        m_enemyStateMachine = animator.transform.GetComponent<EnemySimpleStateMachine>();
        m_agent.isStopped = true;
    }
    
    override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(m_playerTransform);
        if (m_enemyStateMachine.IsPlayerInAttackRange(m_playerTransform) == true)
        {
            m_enemyStateMachine.Shoot();
        }
        else
        {
            animator.SetTrigger("Chase");
        }
        
    }
}
