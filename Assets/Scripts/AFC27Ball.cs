using UnityEngine;

// Control simple del balón. Para una simulación más realista habrá que ajustar masa, fricción y física.
[RequireComponent(typeof(Rigidbody))]
public class AFC27Ball : MonoBehaviour
{
    public float kickForce = 8f;
    public float liftForce = 1.4f;
    private Rigidbody body;

    void Awake() { body = GetComponent<Rigidbody>(); }

    public void Kick(Vector3 direction, float power = 1f)
    {
        direction.y = Mathf.Max(direction.y, 0.08f);
        body.AddForce((direction.normalized * kickForce + Vector3.up * liftForce) * power,
            ForceMode.Impulse);
    }
}
