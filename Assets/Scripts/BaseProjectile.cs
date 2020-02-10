using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : Shootable
{
    [SerializeField] protected float startingDistance;
    [SerializeField] protected float speed;

    new protected Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void OnShot(Transform shooterTransform)
    {
        transform.rotation = shooterTransform.rotation;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        transform.position = shooterTransform.position + shooterTransform.up * startingDistance;
        gameObject.SetActive(true);
        rigidbody.velocity = shooterTransform.up * speed;
        StartCoroutine(AfterShotRoutine(shooterTransform));
    }

    protected virtual IEnumerator AfterShotRoutine(Transform shooterTransform)
    {
        yield break;
    }
}
