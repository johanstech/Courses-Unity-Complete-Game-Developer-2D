using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem trailEffect;

    CapsuleCollider2D _playerBoard;

    void Start()
    {
        _playerBoard = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && _playerBoard.IsTouching(other.collider))
        {
            trailEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        trailEffect.Stop();
    }
}

