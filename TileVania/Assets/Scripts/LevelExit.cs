using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
  [SerializeField]
  float levelLoadDelay = 0.5f;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag != "Player")
    {
      return;
    }

    StartCoroutine(LoadNextLevel());
  }

  IEnumerator LoadNextLevel()
  {
    yield return new WaitForSecondsRealtime(levelLoadDelay);

    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextSceneIndex = 0;
    }

    FindObjectOfType<ScenePersist>().ResetScenePersist();
    SceneManager.LoadScene(nextSceneIndex);
  }
}
