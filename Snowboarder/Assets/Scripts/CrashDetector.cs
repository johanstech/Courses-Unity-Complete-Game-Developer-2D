using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float reloadDelay = 0.5f;
    [SerializeField]
    ParticleSystem bonkEffect;
    [SerializeField]
    AudioClip crashSfx;

    CircleCollider2D _playerHead;

    void Start()
    {
        _playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && _playerHead.IsTouching(other.collider))
        {
            bonkEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSfx);
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
