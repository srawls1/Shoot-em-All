using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonPressActivatedProjectile : BaseProjectile
{
    [SerializeField] private string activateButton;

    protected override IEnumerator AfterShotRoutine(Transform shooterTransform)
    {
        while (gameObject.activeSelf)
        {
            if (Input.GetButtonDown(activateButton))
            {
                Activate();
                break;
            }
            yield return null;
        }
    }

    protected abstract void Activate();
}
