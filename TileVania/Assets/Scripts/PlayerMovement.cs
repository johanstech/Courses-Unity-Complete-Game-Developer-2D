using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  float runSpeed = 6f;
  [SerializeField]
  float jumpSpeed = 13f;
  [SerializeField]
  float climbSpeed = 3f;

  Rigidbody2D _myRigidbody;
  Animator _myAnimator;
  CapsuleCollider2D _myCapsuleCollider;
  Vector2 _moveInput;
  float _baseGravityScale;

  void Start()
  {
    _myRigidbody = GetComponent<Rigidbody2D>();
    _myAnimator = GetComponent<Animator>();
    _myCapsuleCollider = GetComponent<CapsuleCollider2D>();

    _baseGravityScale = _myRigidbody.gravityScale;
  }

  void Update()
  {
    Run();
    FlipSprite();
    ClimbLadder();
  }

  void OnMove(InputValue value)
  {
    _moveInput = value.Get<Vector2>();
  }

  void OnJump(InputValue value)
  {
    if (!_myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
    {
      return;
    }

    if (value.isPressed)
    {
      _myRigidbody.velocity += new Vector2(0f, jumpSpeed);
    }
  }

  void Run()
  {
    Vector2 runVelocity = new Vector2(_moveInput.x * runSpeed, _myRigidbody.velocity.y);
    _myRigidbody.velocity = runVelocity;

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

  void ClimbLadder()
  {
    if (!_myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
    {
      _myRigidbody.gravityScale = _baseGravityScale;
      _myAnimator.SetBool("isClimbing", false);
      return;
    }

    Vector2 climbVelocity = new Vector2(_myRigidbody.velocity.x, _moveInput.y * climbSpeed);
    _myRigidbody.velocity = climbVelocity;
    _myRigidbody.gravityScale = 0f;

    bool playerHasVerticalSpeed = Mathf.Abs(_myRigidbody.velocity.y) > Mathf.Epsilon;
    _myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
  }
}
