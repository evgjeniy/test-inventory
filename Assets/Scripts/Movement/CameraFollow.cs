using UnityEngine;

namespace Movement
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void LateUpdate() => LookAtTarget();

        [ContextMenu("Look at target")]
        private void LookAtTarget()
        {
            if (target == null) return;

            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}