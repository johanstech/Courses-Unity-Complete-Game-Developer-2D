using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  [SerializeField]
  float moveSpeed = 10f;

  // private variables
  Vector2 _rawInput;

  void Update()
  {
    Move();
  }

  void Move()
  {
    Vector3 delta = _rawInput * moveSpeed * Time.deltaTime;
    transform.position += delta;
  }

  void OnMove(InputValue value)
  {
    _rawInput = value.Get<Vector2>();
  }
}
