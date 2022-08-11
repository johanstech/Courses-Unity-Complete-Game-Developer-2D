using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject thingToFollow;

    int _zIndex = -10;

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, _zIndex);
    }
}
