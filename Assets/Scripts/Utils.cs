using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtils {
    public static class Utils {
        public static Vector3 RandomDirection() 
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        public static Vector2 GetRandomPositionInSpawnArea(Vector2 spawnAreaMin, Vector2 spawnAreaMax)
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            return new Vector2(randomX, randomY);
        }
    }
}