using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTest : MonoBehaviour
{
    public Shootable shootableObject;

    void Start()
    {
        shootableObject.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        if (Input.GetButtonDown("Fire"))
        {
            if (shootableObject.gameObject.activeInHierarchy)
            {
                shootableObject.gameObject.SetActive(false);
            }
            else
            {
                shootableObject.OnShot(transform);
            }
        }
    }
}
