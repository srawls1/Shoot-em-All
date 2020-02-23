using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandProjectile : OnContactActivatingProjectile
{
    private Animator animator;

    new protected void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    protected override void Activate()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        animator.SetTrigger("Slap");
    }
}
