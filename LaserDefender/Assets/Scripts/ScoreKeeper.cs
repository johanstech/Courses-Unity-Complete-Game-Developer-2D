using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
  int _score;

  public int GetScore() => _score;

  public void UpdateScore(int value)
  {
    _score += value;
    Mathf.Clamp(_score, 0, int.MaxValue);
  }

  public void ResetScore() => _score = 0;
}
