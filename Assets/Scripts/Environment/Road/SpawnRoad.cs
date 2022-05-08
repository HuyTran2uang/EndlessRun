using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : UpdateMonoBehaviour
{
    public GameObject Road;
    public Vector3 NextSpawnPoint;
    public Transform ParentSpawn;
    public int CountRoad;

    protected override void LoadComponent()
    {
        base.LoadComponent();

        Road = Resources.Load<GameObject>("Prefabs/Road");
        ParentSpawn = this.transform;
    }

    public virtual void SpawnTile()
    {
        GameObject template = Instantiate(Road, NextSpawnPoint, Quaternion.identity, ParentSpawn);
        NextSpawnPoint = template.transform.Find("NextSpawnPoint").transform.position;
    }

    protected virtual void Start()
    {
        for (int i = 0; i < 15; i++)
            SpawnTile();
    }

    protected override void Update()
    {
        base.Update();
        CountRoad = transform.childCount;
    }
}
