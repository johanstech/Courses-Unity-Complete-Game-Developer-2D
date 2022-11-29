using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  [SerializeField]
  float sceneLoadDelay = 2f;

  ScoreKeeper _scoreKeeper;

  void Awake()
  {
    _scoreKeeper = FindObjectOfType<ScoreKeeper>();
  }

  public void QuitGame() => Application.Quit();

  public void LoadMainMenu() => SceneManager.LoadScene("MainMenu");

  public void LoadGame()
  {
    _scoreKeeper.ResetScore();
    SceneManager.LoadScene("Game");
  }

  public void LoadGameOver() => StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));

  IEnumerator WaitAndLoad(string scene, float delay)
  {
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(scene);
  }
}
