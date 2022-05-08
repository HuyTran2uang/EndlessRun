using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSensor : MonoBehaviour
{
    public bool IsGrounded;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
            IsGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 6)
            IsGrounded = false;
    }
}
