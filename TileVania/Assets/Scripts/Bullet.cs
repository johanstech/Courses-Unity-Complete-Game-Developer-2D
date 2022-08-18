using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField]
  float bulletSpeed = 20f;

  Rigidbody2D _myRigidbody;
  PlayerMovement _player;
  float xSpeed;

  void Start()
  {
    _myRigidbody = GetComponent<Rigidbody2D>();
    _player = FindObjectOfType<PlayerMovement>();
    xSpeed = _player.transform.localScale.x * bulletSpeed;
  }

  void Update()
  {
    _myRigidbody.velocity = new Vector2(xSpeed, 0f);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Enemy")
    {
      other.GetComponent<EnemyMovement>().Die();
    }

    Destroy(gameObject);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Destroy(gameObject);
  }
}
