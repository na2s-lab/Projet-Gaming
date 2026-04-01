using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.1f;
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    [Header("Limites caméra")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

        Vector3 finalPosition = new Vector3(clampedX, clampedY, -10f);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            finalPosition,
            ref velocity,
            smoothTime
        );
    }
}