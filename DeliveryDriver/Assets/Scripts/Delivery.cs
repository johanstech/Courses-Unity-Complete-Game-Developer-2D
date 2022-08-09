using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField]
  Color32 baseColour = new Color32(1, 1, 1, 1);
  [SerializeField]
  Color32 hasPackageColour = new Color32(1, 1, 1, 1);
  [SerializeField]
  float destructionDelay = 0.5f;
  
  SpriteRenderer _spriteRenderer;
  bool _hasPackage;
  string _packageMessage = "Package picked up!";
  string _customerMessage = "Package dropped off!";

  void Start() {
    _spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("I HAVE COLLIDED!");
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Package" && !_hasPackage)
    {
      Debug.Log(_packageMessage);
      _hasPackage = true;
      _spriteRenderer.color = hasPackageColour;
      Destroy(other.gameObject, destructionDelay);
    }
    
    if (other.tag == "Customer" && _hasPackage)
    {
      Debug.Log(_customerMessage);
      _hasPackage = false;
      _spriteRenderer.color = baseColour;
    }
  }
}
