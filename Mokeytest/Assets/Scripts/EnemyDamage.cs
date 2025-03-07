using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float health = 100f;  
    [SerializeField] private Healthbar healthbar;  
    [SerializeField] private float playerDamageAmount = 10f;  
    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();

        if (healthbar != null)
        {
            healthbar.UpdateHealthBar(health, health);
        }
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            PlayerCombat playerCombat = other.GetComponentInParent<PlayerCombat>();
            if (playerCombat != null && playerCombat.IsAttacking())
            {
                float attackDamage = playerCombat.GetCurrentAttackDamage();
                TakeDamage(attackDamage);
            }
        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerDamageAmount);  
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (healthbar != null)
        {
            healthbar.UpdateHealthBar(health, 100f);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);  
    }
}
