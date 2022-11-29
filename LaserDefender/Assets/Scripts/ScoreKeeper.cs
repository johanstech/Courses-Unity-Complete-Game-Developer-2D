using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
  int _score;

  static ScoreKeeper instance;

  void Awake()
  {
    ManageSingleton();
  }

  void ManageSingleton()
  {
    if (instance != null)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
  }

  public int GetScore() => _score;

  public void UpdateScore(int value)
  {
    _score += value;
    Mathf.Clamp(_score, 0, int.MaxValue);
  }

  public void ResetScore() => _score = 0;
}
