using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  [SerializeField]
  float paddingLeft = 0.5f;
  [SerializeField]
  float paddingRight = 0.5f;
  [SerializeField]
  float paddingTop = 5f;
  [SerializeField]
  float paddingBottom = 2f;
  [SerializeField]
  float moveSpeed = 10f;

  Shooter _shooter;
  Vector2 _minBounds;
  Vector2 _maxBounds;
  Vector2 _rawInput;

  void Awake()
  {
    _shooter = GetComponent<Shooter>();
  }

  void Start()
  {
    InitBounds();
  }

  void Update()
  {
    Move();
  }

  void InitBounds()
  {
    Camera mainCamera = Camera.main;
    _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
    _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
  }

  void Move()
  {
    Vector2 delta = _rawInput * moveSpeed * Time.deltaTime;
    Vector2 newPos = new Vector2();
    newPos.x = Mathf.Clamp(transform.position.x + delta.x, _minBounds.x + paddingLeft, _maxBounds.x - paddingRight);
    newPos.y = Mathf.Clamp(transform.position.y + delta.y, _minBounds.y + paddingBottom, _maxBounds.y - paddingTop);
    transform.position = newPos;
  }

  void OnMove(InputValue value)
  {
    _rawInput = value.Get<Vector2>();
  }

  void OnFire(InputValue value)
  {
    if (_shooter == null) return;

    _shooter.isFiring = value.isPressed;
  }
}
