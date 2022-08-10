using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    float reloadDelay = 1f;
    [SerializeField]
    ParticleSystem finishEffect;

    bool _finished;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_finished)
        {
            return;
        }

        if (other.tag == "Player")
        {
            _finished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
