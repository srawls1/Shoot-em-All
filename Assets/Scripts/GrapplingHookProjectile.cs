using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookProjectile : AfterDistanceActivatingProjectile
{
    [SerializeField] private float pullDuration;

    private Transform shooter;

    protected override IEnumerator AfterShotRoutine(Transform shooterTransform)
    {
        shooter = shooterTransform;
        return base.AfterShotRoutine(shooterTransform);
    }

    protected override void Activate()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(PullShooterIn());
    }

    private IEnumerator PullShooterIn()
    {
        Vector2 start = shooter.position;
        Vector2 end = transform.position;

        for (float dt = 0f; dt < pullDuration; dt += Time.deltaTime)
        {
            shooter.position = Vector2.Lerp(start, end, dt / pullDuration);
            yield return null;
        }
    }
}
