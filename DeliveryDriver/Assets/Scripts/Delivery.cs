using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField]
  float destructionDelay = 0.5f;

  string _packageMessage = "Package picked up!";
  string _customerMessage = "Package dropped off!";
  bool _hasPackage;

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("I HAVE COLLIDED!");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Package" && !_hasPackage)
    {
      _hasPackage = true;
      Destroy(other.gameObject, destructionDelay);
      Debug.Log(_packageMessage);
    }
    
    if (other.tag == "Customer" && _hasPackage)
    {
      _hasPackage = false;
      Debug.Log(_customerMessage);
    }
  }
}
