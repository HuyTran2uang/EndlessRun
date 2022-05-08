using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject Obstacle;
    public Vector3 NextSpawnPoint;
    public Transform ParentSpawn;
    public int CountObstacle;

    private void Awake()
    {
        LoadComponent();
    }

    private void Reset()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        Obstacle = Resources.Load<GameObject>("Prefabs/Obstacle");
        ParentSpawn = this.transform;
    }

    public void SpawnObstacles()
    {
        // GameObject template = Instantiate(Obstacle, NextSpawnPoint, Quaternion.identity, ParentSpawn);
        // NextSpawnPoint = template.transform.Find("NextSpawnPoint").transform.position;
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
            SpawnObstacles();
    }

    private void Update()
    {
        CountObstacle = transform.childCount;
    }
}
