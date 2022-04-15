using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float  chaseRange = 5f;
    [SerializeField] float turnSpeed = 8f;
    [SerializeField] float  distanceToTarget = Mathf.Infinity;
    [SerializeField] bool  isProvoked = false;

    Transform target;
    NavMeshAgent naveMesgAgent;
    Animator animator;
    EnemyHealth enamyHealth;
    void Start()
    {
        naveMesgAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enamyHealth = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    void Update()
    {
        if (enamyHealth.IsDead())
        {
            enabled = true;
            naveMesgAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(
            target.position, transform.position
        );
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= naveMesgAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (distanceToTarget < naveMesgAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        animator.SetBool("Attack", true);
        // print("Enemy Attacking");
    }

    private void ChaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");

        if (naveMesgAgent.enabled == true) naveMesgAgent.SetDestination(target.position);

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(
            transform.rotation, lookRotation, Time.deltaTime * turnSpeed
            );
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
}
