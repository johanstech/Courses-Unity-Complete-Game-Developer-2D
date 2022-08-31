using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField]
  List<WaveConfigSO> waveConfigs;
  [SerializeField]
  float waveDelay = 3f;

  WaveConfigSO _currentWave;

  void Start()
  {
    StartCoroutine(SpawnEnemyWaves());
  }

  public WaveConfigSO GetCurrentWave() => _currentWave;

  IEnumerator SpawnEnemyWaves()
  {
    foreach (WaveConfigSO wave in waveConfigs)
    {
      _currentWave = wave;
      StartCoroutine(SpawnEnemies());
      yield return new WaitForSeconds(waveDelay);
    }
  }

  IEnumerator SpawnEnemies()
  {
    for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
    {
      Instantiate(_currentWave.GetEnemyPrefab(0), _currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
      yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
    }
  }
}
