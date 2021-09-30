using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Animator m_animator;
    private Transform m_playerTransform;
    private UnityEngine.AI.NavMeshAgent m_agent;
    private EnemySimpleStateMachine m_enemyStateMachine;
    //float visionDistance = 15f;
    //float visionAngle = 90;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_animator = animator;
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.isStopped = true;
        m_enemyStateMachine = animator.transform.GetComponent<EnemySimpleStateMachine>();
        m_playerTransform = animator.transform.GetComponent<EnemySimpleStateMachine>().m_player.transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_enemyStateMachine.CanSeePlayer(m_playerTransform) == true)
        {
            animator.SetTrigger("Chase");
        }

        //float hearingDistance = Vector3.Distance(animator.transform.position, m_playerTransform.position);

        //if (hearingDistance < 10)
        //{
        //    animator.SetTrigger("Chase");
        //}

        //if (Vector3.Angle(animator.transform.forward, m_playerTransform.position - animator.transform.position) < visionAngle)
        //{
        //    RaycastHit hit;
        //    bool m_Raycast = Physics.Raycast(animator.transform.position, animator.transform.forward, out hit, visionDistance);
        //    if (m_Raycast && hit.transform.CompareTag("Player"))
        //    {
        //        animator.SetTrigger("Chase");
        //    }
        //}
    }
}
