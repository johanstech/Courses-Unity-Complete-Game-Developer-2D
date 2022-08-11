using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz _quiz;
    End _end;

    void Awake() {
        _quiz = FindObjectOfType<Quiz>();
        _end = FindObjectOfType<End>();
    }

    void Start()
    {
        _quiz.gameObject.SetActive(true);
        _end.gameObject.SetActive(false);
    }

    void Update()
    {
        if (_quiz.isComplete)
        {
            _quiz.gameObject.SetActive(false);
            _end.gameObject.SetActive(true);
            _end.ShowFinalScore();
        }
    }

    public void OnReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
