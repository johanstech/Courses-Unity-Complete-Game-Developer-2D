using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  float runSpeed = 10f;

  Rigidbody2D _myRigidbody;
  Animator _myAnimator;
  Vector2 _moveInput;

  void Start()
  {
    _myRigidbody = GetComponent<Rigidbody2D>();
    _myAnimator = GetComponent<Animator>();
  }

  void Update()
  {
    Run();
    FlipSprite();
  }

  void OnMove(InputValue value)
  {
    _moveInput = value.Get<Vector2>();
  }

  void Run()
  {
    Vector2 playerVelocity = new Vector2(_moveInput.x * runSpeed, _myRigidbody.velocity.y);
    _myRigidbody.velocity = playerVelocity;

    bool playerHasHorizontalSpeed = Mathf.Abs(_myRigidbody.velocity.x) > Mathf.Epsilon;

    _myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
  }

  void FlipSprite()
  {
    bool playerHasHorizontalSpeed = Mathf.Abs(_myRigidbody.velocity.x) > Mathf.Epsilon;

    if (playerHasHorizontalSpeed)
    {
      transform.localScale = new Vector2(Mathf.Sign(_myRigidbody.velocity.x), 1f);
    }
  }
}
