using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteAbility : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.Play("IgniteSpell");
        }
    }
}
