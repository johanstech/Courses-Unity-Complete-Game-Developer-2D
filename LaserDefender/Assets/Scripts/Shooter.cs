using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField]
  GameObject projectilePrefab;
  [SerializeField]
  float projectileSpeed = 10f;
  [SerializeField]
  float projectileLifetime = 5f;
  [SerializeField]
  float firingRate = 5f;

  public bool isFiring;

  Coroutine _firingCoroutine;

  void Start()
  {

  }

  void Update()
  {
    Fire();
  }

  void Fire()
  {
    if (isFiring && _firingCoroutine == null)
    {
      _firingCoroutine = StartCoroutine(FireContinuously());
    }
    else if (!isFiring && _firingCoroutine != null)
    {
      StopCoroutine(_firingCoroutine);
      _firingCoroutine = null;
    }
  }

  IEnumerator FireContinuously()
  {
    while (true)
    {
      GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
      Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
      if (rb)
      {
        rb.velocity = transform.up;
      }
      Destroy(instance, projectileLifetime);
      yield return new WaitForSeconds(firingRate);
    }
  }
}
