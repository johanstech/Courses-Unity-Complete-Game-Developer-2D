using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  [SerializeField]
  TextMeshProUGUI livesText;
  [SerializeField]
  TextMeshProUGUI scoreText;
  [SerializeField]
  int playerLives = 3;
  [SerializeField]
  int playerScore = 0;

  void Awake()
  {
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
    if (numGameSessions > 1)
    {
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start()
  {
    livesText.text = playerLives.ToString();
    scoreText.text = playerScore.ToString();
  }

  public void ProcessPlayerDeath()
  {
    if (playerLives > 1)
    {
      DecrementLife();
    }
    else
    {
      ResetGameSession();
    }
  }

  public void AddToScore(int pointsToAdd)
  {
    playerScore += pointsToAdd;
    scoreText.text = playerScore.ToString();
  }

  void DecrementLife()
  {
    playerLives--;
    livesText.text = playerLives.ToString();
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  void ResetGameSession()
  {
    FindObjectOfType<ScenePersist>().ResetScenePersist();
    SceneManager.LoadScene(0);
    Destroy(gameObject);
  }
}
