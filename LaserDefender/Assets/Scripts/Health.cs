using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField]
  int health = 50;
  [SerializeField]
  ParticleSystem explodeEffect;

  [SerializeField]
  bool applyCameraShake;

  CameraShake _cameraShake;

  public int GetHealth() => health;

  void Awake()
  {
    _cameraShake = Camera.main.GetComponent<CameraShake>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    DamageDealer damageDealer = other.GetComponent<DamageDealer>();
    if (damageDealer)
    {
      TakeTamage(damageDealer.GetDamage());
      PlayExplodeEffect();
      ShakeCamera();
      damageDealer.Hit();
    }
  }

  void TakeTamage(int damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Destroy(gameObject);
    }
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
