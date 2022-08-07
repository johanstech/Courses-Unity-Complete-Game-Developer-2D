using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField]
  float turnSpeed = 200f;
  [SerializeField]
  float moveSpeed = 10f;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
    float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -turnAmount);
    transform.Translate(0, moveAmount, 0);
  }
}
