using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [Header("General")]
  [SerializeField]
  GameObject projectilePrefab;
  [SerializeField]
  float projectileSpeed = 10f;
  [SerializeField]
  float projectileLifetime = 5f;
  [SerializeField]
  float baseFiringDelay = 0.2f;

  [Header("AI")]
  [SerializeField]
  bool useAI;
  [SerializeField]
  float firingDelayVariance = 0f;
  [SerializeField]
  float minimumFiringDelay = 0.1f;

  [HideInInspector]
  public bool isFiring;

  Coroutine _firingCoroutine;
  AudioPlayer _audioPlayer;

  void Awake()
  {
    _audioPlayer = FindObjectOfType<AudioPlayer>();
  }

  void Start()
  {
    if (useAI)
    {
      isFiring = true;
    }
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
        rb.velocity = transform.up * projectileSpeed;
      }
      Destroy(instance, projectileLifetime);
      float actualFiringDelay = Random.Range(baseFiringDelay - firingDelayVariance, baseFiringDelay + firingDelayVariance);
      actualFiringDelay = Mathf.Clamp(actualFiringDelay, minimumFiringDelay, float.MaxValue);
      _audioPlayer.PlayShootingClip();
      yield return new WaitForSeconds(actualFiringDelay);
    }
  }
}
