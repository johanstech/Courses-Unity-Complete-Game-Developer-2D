using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
  EnemySpawner _enemySpawner;
  WaveConfigSO _waveConfig;
  List<Transform> _waypoints;
  int _waypointIndex = 0;

  void Awake()
  {
    _enemySpawner = FindObjectOfType<EnemySpawner>();
  }

  void Start()
  {
    _waveConfig = _enemySpawner.GetCurrentWave();
    _waypoints = _waveConfig.GetWaypoints();
    transform.position = _waypoints[_waypointIndex].position;
  }

  void Update()
  {
    FollowPath();
  }

  void FollowPath()
  {
    if (_waypointIndex < _waypoints.Count)
    {
      Vector3 targetPos = _waypoints[_waypointIndex].position;
      float delta = _waveConfig.GetMoveSpeed() * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
      if (transform.position == targetPos)
      {
        _waypointIndex++;
      }
    }
    else
    {
      Destroy(gameObject);
    }
  }
}
