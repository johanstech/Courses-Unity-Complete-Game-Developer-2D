using UnityEngine;

public class Delivery : MonoBehaviour
{
  string _packageMessage = "Package picked up!";
  string _customerMessage = "Package dropped off!";

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("I HAVE COLLIDED!");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("I AM TRIGGERED!");
  }
}
