using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
  [SerializeField]
  float shakeDuration = 0.3f;
  [SerializeField]
  float shakeMagnitude = 0.15f;

  Vector3 _initialPosition;

  void Start()
  {
    _initialPosition = transform.position;
  }

  public void Play()
  {
    StartCoroutine(Shake());
  }

  IEnumerator Shake()
  {
    float elapsedTime = 0;
    while (elapsedTime < shakeDuration)
    {
      transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
      elapsedTime += Time.deltaTime;
      yield return new WaitForEndOfFrame();
    }
    transform.position = _initialPosition;
  }
}
