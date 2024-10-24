using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float jumpStrong = 10f;
    protected Vector3 A = new Vector3(-1, 0, 0);
    protected Vector3 D = new Vector3(1, 0, 0);
    protected Vector3 W = new Vector3(0, 0, 1);
    protected Vector3 S = new Vector3(0, 0, -1);
    protected Vector3 jumpVector = new Vector3(0, 1, 0);
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKey("a"))
        {
            this.Moving(A);
        }
        else if (Input.GetKey("d"))
        {
            this.Moving(D);
        }
        else if (Input.GetKey("w"))
        {
            this.Moving(W);
        }
        else if (Input.GetKey("s"))
        {
            this.Moving(S);
        }
        if (Input.GetKeyDown("space"))
        {
            this.Jump(jumpVector);
        }
    }
    protected virtual void Moving(Vector3 moveVector)
    {
        rb.velocity = moveVector * speed;
    }
    protected virtual void Jump(Vector3 jumpVector)
    {
        rb.velocity = jumpVector * jumpStrong;
    }
}
