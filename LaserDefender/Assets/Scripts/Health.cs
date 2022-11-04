using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField]
  int health = 50;
  [SerializeField]
  ParticleSystem explodeEffect;

  public int GetHealth() => health;

  void OnTriggerEnter2D(Collider2D other)
  {
    DamageDealer damageDealer = other.GetComponent<DamageDealer>();
    if (damageDealer)
    {
      TakeTamage(damageDealer.GetDamage());
      PlayExplodeEffect();
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
}
