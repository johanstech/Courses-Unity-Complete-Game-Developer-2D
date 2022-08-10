using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    float reloadDelay = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
