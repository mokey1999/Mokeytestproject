using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAbility : MonoBehaviour
{
    public float damageAmount = 20f;
    public GameObject aoeSpellObject;

    private Animator animator;
    private Collider[] aoeColliders;

    void Start()
    {
        aoeColliders = aoeSpellObject.GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.Play("AOEspell_1");
            DealDamageInAOE();
        }
    }

    private void DealDamageInAOE()
    {
        foreach (var collider in aoeColliders)
        {
            if (collider != null && collider.isTrigger && collider.CompareTag("Enemy"))
            {
                EnemyDamage enemyDamage = collider.GetComponent<EnemyDamage>();
                if (enemyDamage != null)
                {
                    enemyDamage.TakeDamage(damageAmount);
                }
            }
        }
    }
}
