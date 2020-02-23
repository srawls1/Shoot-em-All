using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnContactActivatingProjectile : BaseProjectile
{
    [SerializeField] private string[] otherObjectTags;

    private HashSet<string> tagSet;

    new protected void Awake()
    {
        base.Awake();
        tagSet = new HashSet<string>(otherObjectTags);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (tagSet.Contains(collider.gameObject.tag))
        {
            Activate();
        }
    }

    protected abstract void Activate();
}
