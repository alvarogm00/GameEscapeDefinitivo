using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : StateMachineBehaviour
{
    Animator m_animator;
    private UnityEngine.AI.NavMeshAgent m_agent;
    private Collider m_collider;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_collider = animator.transform.GetComponent<Collider>();
        m_agent = animator.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.isStopped = true;
        m_collider.enabled = false;
    }
}
