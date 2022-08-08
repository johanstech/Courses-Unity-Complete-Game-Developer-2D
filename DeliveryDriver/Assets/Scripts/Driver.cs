using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField]
  float turnSpeed = 200f;
  [SerializeField]
  float moveSpeed = 10f;

  void Start()
  {
  }

  void Update()
  {
    float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
    float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -turnAmount);
    transform.Translate(0, moveAmount, 0);
  }
}
