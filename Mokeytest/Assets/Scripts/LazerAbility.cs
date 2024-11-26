using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAbility : MonoBehaviour
{
    private Animator animator;
    private bool isLazerActive = false;
    private PlayerController playerMovement;

    [SerializeField] private GameObject lazerCube;
    [SerializeField] private float damageAmount = 10f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ActivateLazer();
        }
        else
        {
            DeactivateLazer();
        }
    }

    private void ActivateLazer()
    {
        if (!isLazerActive)
        {
            isLazerActive = true;
            animator.Play("LazerSpell");
            lazerCube.SetActive(true);
            playerMovement.DisableMovement();
        }

        Collider[] enemiesHit = Physics.OverlapBox(lazerCube.transform.position, lazerCube.transform.localScale / 2f);
        foreach (Collider enemy in enemiesHit)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyDamage>().TakeDamage(damageAmount * Time.deltaTime);
            }
        }
    }

    private void DeactivateLazer()
    {
        if (isLazerActive)
        {
            isLazerActive = false;
            animator.Play("Idle");
            lazerCube.SetActive(false);
            playerMovement.EnableMovement();
        }
    }
}
