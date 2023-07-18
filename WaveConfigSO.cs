using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnDelayVariance = 0f;
    [SerializeField] float minSpawnDelay = 0.2f;
    

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab) {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public int GetEnemyCount() {
            return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public float GetRandomSpawnTime() {
        float spawnTime = Random.Range(spawnDelay - spawnDelayVariance, spawnDelay + spawnDelayVariance);
        return Mathf.Clamp(spawnTime, minSpawnDelay, float.MaxValue);
    }


}
