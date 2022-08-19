using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  float runSpeed = 7f;
  [SerializeField]
  float jumpSpeed = 20f;
  [SerializeField]
  float climbSpeed = 5f;
  [SerializeField]
  Vector2 deathKick = new Vector2(20f, 20f);
  [SerializeField]
  GameObject bullet;
  [SerializeField]
  Transform gun;

  public bool isAlive = true;

  Rigidbody2D _myRigidbody;
  Animator _myAnimator;
  CapsuleCollider2D _myBodyCollider;
  BoxCollider2D _myFeetCollider;
  Vector2 _moveInput;
  float _baseGravityScale;

  void Start()
  {
    _myRigidbody = GetComponent<Rigidbody2D>();
    _myAnimator = GetComponent<Animator>();
    _myBodyCollider = GetComponent<CapsuleCollider2D>();
    _myFeetCollider = GetComponent<BoxCollider2D>();

    _baseGravityScale = _myRigidbody.gravityScale;
  }

  void Update()
  {
    if (!isAlive)
    {
      return;
    }

    Run();
    FlipSprite();
    ClimbLadder();
    Die();
  }

  void OnMove(InputValue value)
  {
    if (!isAlive)
    {
      return;
    }

    _moveInput = value.Get<Vector2>();
  }

  void OnJump(InputValue value)
  {
    if (!isAlive)
    {
      return;
    }

    if (!_myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
    {
      return;
    }

    if (value.isPressed)
    {
      _myRigidbody.velocity += new Vector2(0f, jumpSpeed);
    }
  }

  void OnFire(InputValue value)
  {
    if (!isAlive)
    {
      return;
    }

    Instantiate(bullet, gun.position, transform.rotation);
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
    if (!_myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
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

  void Die()
  {
    if (_myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
    {
      isAlive = false;
      _myAnimator.SetTrigger("Dying");
      _myRigidbody.velocity = deathKick;
      FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
  }
}
