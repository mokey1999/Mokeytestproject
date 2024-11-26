using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{
    private Animator animator;
    private PlayerHealth playerHealth;
    private float healAmount = 20f;
    private float moveDistance = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            HealAndMove();
        }
    }

    private void HealAndMove()
    {
        animator.Play("HealingSpell");

        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
        }

        transform.Translate(Vector3.forward * moveDistance);
    }
}
