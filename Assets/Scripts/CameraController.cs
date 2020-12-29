using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 positionToFollow;
    public float speed;
    public float zOffset;

    private void Start()
    {
        positionToFollow = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, positionToFollow, speed);
    }

    public void FollowPosition(Vector3 position)
    {
        positionToFollow = position + Vector3.forward * zOffset;
    }
}