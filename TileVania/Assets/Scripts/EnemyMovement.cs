using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  [SerializeField]
  float moveSpeed = 1f;

  Rigidbody2D _myRigidbody;

  void Start()
  {
    _myRigidbody = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    _myRigidbody.velocity = new Vector2(moveSpeed, 0f);
  }

  void OnTriggerExit2D(Collider2D other)
  {
    moveSpeed = -moveSpeed;
    FlipSprite();
  }

  void FlipSprite()
  {
    transform.localScale = new Vector2(-(Mathf.Sign(_myRigidbody.velocity.x)), 1f);
  }
}
