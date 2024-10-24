using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulleMoving : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    private void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        transform.parent.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
