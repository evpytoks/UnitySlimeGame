using System.Collections;
using System.Collections.Generic;
using GameUtils;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;

    private void Start()
    {
        InvokeRepeating("SpawnSlime", 0f, spawnInterval);
    }

    private void SpawnSlime()
    {
        
        Vector2 randomPosition = Utils.GetRandomPositionInSpawnArea(spawnAreaMin, spawnAreaMax);

        Instantiate(slimePrefab, randomPosition, Quaternion.identity);
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnSlime");
    }
}