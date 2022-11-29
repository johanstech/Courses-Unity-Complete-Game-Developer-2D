using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
  [SerializeField]
  TextMeshProUGUI scoreText;

  ScoreKeeper _scoreKeeper;

  private void Awake()
  {
    _scoreKeeper = FindObjectOfType<ScoreKeeper>();
  }

  void Start()
  {
    scoreText.text = $"you scored:\n{_scoreKeeper.GetScore()}";
  }
}
