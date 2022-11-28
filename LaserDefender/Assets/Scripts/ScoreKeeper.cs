using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
  int _score;

  public int GetScore() => _score;

  public void UpdateScore(int value)
  {
    _score += value;
    Mathf.Clamp(_score, 0, int.MaxValue);
    Debug.Log(_score);
  }

  public void ResetScore() => _score = 0;
}
