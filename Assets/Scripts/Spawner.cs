using System.Collections;
using System.Collections.Generic;
using GameUtils;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    private void Spawn()
    {
        
        Vector2 randomPosition = Utils.GetRandomPositionInSpawnArea(spawnAreaMin, spawnAreaMax);

        Instantiate(objectPrefab, randomPosition, Quaternion.identity);
    }

    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }
}