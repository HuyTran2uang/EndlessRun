using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public CoinSensor CoinSensor;
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
        CoinSensor = transform.Find("CoinSensor").GetComponent<CoinSensor>();
    }

    private void LoadGlobalComponent()
    {
        PlayerTransform = GameObject.FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    private void Update()
    {
        if (PlayerGetCoin())
        {
            Destroy(this.gameObject);
        }

        if (PlayerTransform.position.z - transform.position.z >= distanceDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, Time.deltaTime, 0);
    }

    private bool PlayerGetCoin()
    {
        return CoinSensor.IsPlayer;
    }
}
