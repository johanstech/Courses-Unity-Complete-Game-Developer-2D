using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField]
  bool isPlayer;
  [SerializeField]
  int health = 50;
  [SerializeField]
  int score = 10;
  [SerializeField]
  ParticleSystem explodeEffect;

  [SerializeField]
  bool applyCameraShake;
  CameraShake _cameraShake;

  AudioPlayer _audioPlayer;
  ScoreKeeper _scoreKeeper;
  LevelManager _levelManager;

  public int GetHealth() => health;

  void Awake()
  {
    _cameraShake = Camera.main.GetComponent<CameraShake>();
    _audioPlayer = FindObjectOfType<AudioPlayer>();
    _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    _levelManager = FindObjectOfType<LevelManager>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    DamageDealer damageDealer = other.GetComponent<DamageDealer>();
    if (damageDealer)
    {
      TakeDamage(damageDealer.GetDamage());
      PlayExplodeEffect();
      _audioPlayer.PlayDamageClip();
      ShakeCamera();
      damageDealer.Hit();
    }
  }

  void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    if (!isPlayer)
    {
      _scoreKeeper.UpdateScore(score);
    }
    else
    {
      _levelManager.LoadGameOver();
    }
    Destroy(gameObject);
  }

  void PlayExplodeEffect()
  {
    if (explodeEffect != null)
    {
      ParticleSystem instance = Instantiate(explodeEffect, transform.position, Quaternion.identity);
      Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }
  }

  void ShakeCamera()
  {
    if (_cameraShake != null && applyCameraShake)
    {
      _cameraShake.Play();
    }
  }
}
