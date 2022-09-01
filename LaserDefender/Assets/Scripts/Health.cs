using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField]
  int health = 50;

  public int GetHealth() => health;

  void OnTriggerEnter2D(Collider2D other)
  {
    DamageDealer damageDealer = other.GetComponent<DamageDealer>();
    if (damageDealer)
    {
      TakeTamage(damageDealer.GetDamage());
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
}
