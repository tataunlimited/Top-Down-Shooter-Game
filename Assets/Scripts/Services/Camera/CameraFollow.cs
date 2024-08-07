using UnityEngine;

namespace Services.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;       // The target that the camera will follow
        [SerializeField] private float smoothSpeed = 0.125f;  // The speed with which the camera will follow the target
        [SerializeField] private Vector3 offset;         // Offset from the target

        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;

        }
    }
}