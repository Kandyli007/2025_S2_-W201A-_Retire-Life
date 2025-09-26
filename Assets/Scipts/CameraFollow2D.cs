using UnityEngine;
public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float zOffset = -10f;
    void LateUpdate()
    {
        if (target != null)
            transform.position = new Vector3(target.position.x, target.position.y, zOffset);
    }
}

