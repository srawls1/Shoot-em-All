using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProjectile : ButtonPressActivatedProjectile
{
    [SerializeField] private float angularSpeed;
    [SerializeField] private Shootable bulletPrefab;
    [SerializeField] private float bulletFrequency;
    [SerializeField] private int numBullets;


    protected override IEnumerator AfterShotRoutine(Transform shooterTransform)
    {
        Rotate(angularSpeed);
        return base.AfterShotRoutine(shooterTransform);
    }

    protected override void Activate()
    {
        StartCoroutine(ShootingRoutine());
    }

    protected IEnumerator ShootingRoutine()
    {
        for (int i = 0; i < numBullets; ++i)
        {
            Shootable shootable = Instantiate(bulletPrefab);
            shootable.OnShot(transform);
            yield return new WaitForSeconds(bulletFrequency);
        }
    }
}
