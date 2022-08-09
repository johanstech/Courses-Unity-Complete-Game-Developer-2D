using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField]
  float turnSpeed = 200f;
  [SerializeField]
  float moveSpeed = 10f;
  [SerializeField]
  float bumpSpeed = 5f;
  [SerializeField]
  float boostSpeed = 20f;
  [SerializeField]
  float destructionDelay = 0.5f;

  void Update()
  {
    float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
    float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -turnAmount);
    transform.Translate(0, moveAmount, 0);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    moveSpeed = bumpSpeed;
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Boost")
    {
      moveSpeed = boostSpeed;
      Destroy(other.gameObject, destructionDelay);
    }
  }
}
