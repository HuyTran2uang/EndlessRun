using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : UpdateMonoBehaviour
{
    public Transform playerTransform;
    public Vector3 Offset;

    protected override void LoadComponent()
    {
        base.LoadComponent();

        playerTransform = GameObject.FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    protected virtual void Start()
    {
        Offset = transform.position - playerTransform.position;
    }

    protected override void Update()
    {
        base.Update();

        Vector3 targetPosition = playerTransform.position + Offset;
        targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
