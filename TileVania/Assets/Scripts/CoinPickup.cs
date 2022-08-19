using UnityEngine;

public class CoinPickup : MonoBehaviour
{
  [SerializeField]
  AudioClip coinPickupSfx;
  [SerializeField]
  int pointsForCoinPickup = 100;

  bool _wasCollected;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag != "Player" || _wasCollected)
    {
      return;
    }

    _wasCollected = true;
    FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
    AudioSource.PlayClipAtPoint(coinPickupSfx, Camera.main.transform.position);
    gameObject.SetActive(false);
    Destroy(gameObject);
  }
}
