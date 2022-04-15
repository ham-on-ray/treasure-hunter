using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    Animator animator;
    bool isDead = false;

    public bool IsDead() => isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float hitAmount)
    {
        BroadcastMessage("OnDamageTaken");
        health -= hitAmount;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        animator.SetTrigger("Die");
        isDead = true;
        // Destroy(gameObject);
    }

    public float ReturnHealth() => health;

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if ( other.gameObject.GetComponent<BulletScript>() )
    //     {
    //         print("hit");
    //     }
    // }
}
