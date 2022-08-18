using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  [SerializeField]
  float moveSpeed = 1f;
  [SerializeField]
  float deathDelay = 0.25f;

  Rigidbody2D _myRigidbody;
  bool _isDead;

  void Start()
  {
    _myRigidbody = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (_isDead)
    {
      return;
    }

    _myRigidbody.velocity = new Vector2(moveSpeed, 0f);
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.tag == "Bullet")
    {
      return;
    }

    moveSpeed = -moveSpeed;
    FlipSprite();
  }

  void FlipSprite()
  {
    transform.localScale = new Vector2(-(Mathf.Sign(_myRigidbody.velocity.x)), 1f);
  }

  public void Die()
  {
    _isDead = true;
    _myRigidbody.velocity = new Vector2(0f, 0f);
    Destroy(gameObject, deathDelay);
  }
}
