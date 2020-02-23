using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : BaseProjectile
{
    [SerializeField] private float angularSpeed;
    [SerializeField] private float distance;
    [SerializeField] private float reversalPeriod;

    protected override IEnumerator AfterShotRoutine(Transform shooterTransform)
    {
        Rotate(angularSpeed);
        float reversalDistance = 0.5f * speed * reversalPeriod;
        float waitDistance = distance - reversalDistance - startingDistance;
        float waitTime = waitDistance / speed;
        yield return new WaitForSeconds(waitTime);

        Vector2 startingVelocity = rigidbody.velocity;
        Vector2 finalVelocity = -startingVelocity;
        for (float dt = 0f; dt < reversalPeriod; dt += Time.deltaTime)
        {
            rigidbody.velocity = Vector2.Lerp(startingVelocity, finalVelocity, dt / reversalPeriod);
            yield return null;
        }
    }
}
