using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float torqueAmount = 1f;
    [SerializeField]
    float baseSpeed = 20f;
    [SerializeField]
    float boostSpeed = 30f;
    [SerializeField]
    float brakeSpeed = 5f;

    Rigidbody2D _rb2d;
    SurfaceEffector2D _se2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        Rotate();
        Boost();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rb2d.AddTorque(-torqueAmount);
        }
    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _se2d.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _se2d.speed = brakeSpeed;
        }
        else
        {
            _se2d.speed = baseSpeed;
        }
    }
}
