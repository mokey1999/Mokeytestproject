using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float health = 100f;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float igniteDuration = 4f;
    [SerializeField] private float igniteDamage = 5f;
    private bool isIgnited = false;
    private float igniteTimer = 0f;
    private float igniteEndTime = 0f;
    private float timeBetweenDamage = 0f;
    private float damageTimePassed = 0f;
    private int damageCounter = 0;
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
        if (isIgnited)
        {
            damageTimePassed += Time.deltaTime;

            if (damageTimePassed >= igniteEndTime || damageCounter >= 3)
            {
                isIgnited = false;
                damageTimePassed = 0f;
                damageCounter = 0;
            }

            if (damageTimePassed >= igniteTimer)
            {
                TakeDamage(igniteDamage);
                igniteTimer += timeBetweenDamage;
                damageCounter++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }

        if (other.CompareTag("AOE_Sphere"))
        {
            TakeDamage(damageAmount);
        }

        if (other.CompareTag("Ignite_Sphere"))
        {
            TakeDamage(damageAmount);
            StartIgnite();
        }
    }

    private void StartIgnite()
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.Play("EnemyBlooding");
        }

        isIgnited = true;
        timeBetweenDamage = igniteDuration / 3f;
        igniteTimer = timeBetweenDamage;
        igniteEndTime = igniteDuration;
        damageTimePassed = 0f;
        damageCounter = 0;
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
