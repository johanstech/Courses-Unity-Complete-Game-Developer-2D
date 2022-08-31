using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
  [SerializeField]
  Transform pathPrefab;
  [SerializeField]
  List<GameObject> enemyPrefabs;
  [SerializeField]
  float moveSpeed = 5f;
  [SerializeField]
  float spawnDelay = 1f;
  [SerializeField]
  float spawnDelayVariance = 0.5f;
  [SerializeField]
  float minimumSpawnTime = 0.2f;

  public Transform GetStartingWaypoint() => pathPrefab.GetChild(0);

  public List<Transform> GetWaypoints()
  {
    List<Transform> waypoints = new List<Transform>();
    foreach (Transform child in pathPrefab)
    {
      waypoints.Add(child);
    }
    return waypoints;
  }

  public int GetEnemyCount() => enemyPrefabs.Count;

  public GameObject GetEnemyPrefab(int index) => enemyPrefabs[index];

  public float GetMoveSpeed() => moveSpeed;

  public float GetRandomSpawnTime()
  {
    float spawnTime = Random.Range(spawnDelay - spawnDelayVariance, spawnDelay + spawnDelayVariance);
    return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
  }
}
