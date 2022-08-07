using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("I HAVE COLLIDED!");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("I AM TRIGGERED!");
  }
}
