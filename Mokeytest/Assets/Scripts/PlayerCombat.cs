using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float lightAttackDamage = 10f;
    public float heavyAttackDamage = 20f;

    private float currentAttackDamage;
    private bool isAttacking = false;

    private void Start()
    {
        currentAttackDamage = lightAttackDamage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentAttackDamage = lightAttackDamage;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentAttackDamage = heavyAttackDamage;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            isAttacking = true;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            isAttacking = false;
        }
    }

    public float GetCurrentAttackDamage()
    {
        return currentAttackDamage;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }
}
