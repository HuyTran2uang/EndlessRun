using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public ObstacleSensor ObstacleSensor;
    public Transform PlayerTransform;
    public float distanceDestroy;

    private void Awake()
    {
        LoadChildComponent();
        LoadGlobalComponent();
    }

    private void Start()
    {
        distanceDestroy = 10.0f;
    }

    private void Reset()
    {
        LoadChildComponent();
        LoadGlobalComponent();
    }

    private void LoadChildComponent()
    {
        ObstacleSensor = transform.Find("ObstacleSensor").GetComponent<ObstacleSensor>();
    }

    private void LoadGlobalComponent()
    {
        PlayerTransform = GameObject.FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    private void Update()
    {
        if (PlayerTransform.position.z - transform.position.z >= distanceDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    private bool IsGrounded()
    {
        return ObstacleSensor.IsGrounded;
    }

    private void Gravity()
    {
        if (IsGrounded()) return;
        Vector3 velocity;
        velocity = new Vector3(0.0f, -9.8f, 0.0f);
        transform.position += velocity * Time.deltaTime;
    }
}
