using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AfterDistanceActivatingProjectile : BaseProjectile
{
    [SerializeField] private float distance;

    protected override IEnumerator AfterShotRoutine(Transform shooterTransform)
    {
        Vector2 startingPos = shooterTransform.position;

        while (Vector2.Distance(transform.position, startingPos) < distance)
        {
            yield return null;
        }

        Activate();
    }

    protected abstract void Activate();
}
