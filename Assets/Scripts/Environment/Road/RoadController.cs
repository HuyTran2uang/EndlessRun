using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public RoadSensor RoadSensor;
    public SpawnRoad SpawnRoad;

    private void Awake()
    {
        LoadChildComponent();
        LoadGlobalComponent();
    }

    private void Reset()
    {
        LoadChildComponent();
        LoadGlobalComponent();
    }

    private void Update()
    {
        if (PlayerExitThisRoad())
        {
            CreateNewRoad();
            DestroyRoad();
        }
    }

    private void LoadChildComponent()
    {
        RoadSensor = transform.Find("RoadSensor").GetComponent<RoadSensor>();
    }

    private void LoadGlobalComponent()
    {
        SpawnRoad = GameObject.FindObjectOfType<SpawnRoad>();
    }

    private bool PlayerExitThisRoad()
    {
        return RoadSensor.CheckPlayerExit;
    }

    private void CreateNewRoad()
    {
        SpawnRoad.SpawnTile();
    }

    private void DestroyRoad()
    {
        Destroy(this.gameObject);
    }
}
