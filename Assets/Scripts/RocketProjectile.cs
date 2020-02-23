using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : OnContactActivatingProjectile
{
    protected override void Activate()
    {
        Debug.Log("Boom");
        Destroy(gameObject);
    }
}
