using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    Vector3 dir;

    private void OnMove(InputValue value)
    {
        if (rb)
        {
            dir = value.Get<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            rb.MovePosition(rb.position + (dir * Time.fixedDeltaTime * 5f));
        }
    }
}
