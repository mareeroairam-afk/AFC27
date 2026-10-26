using UnityEngine;

// Cámara de seguimiento elevada, inspirada en una retransmisión televisiva.
public class AFC27BroadcastCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -13f);
    public float followSharpness = 5f;
    public float lookHeight = 1.2f;

    void LateUpdate()
    {
        if (!target) return;
        Vector3 desired = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desired, 1f - Mathf.Exp(-followSharpness * Time.deltaTime));
        Vector3 lookAt = target.position + Vector3.up * lookHeight;
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(lookAt - transform.position), 1f - Mathf.Exp(-followSharpness * Time.deltaTime));
    }
}
