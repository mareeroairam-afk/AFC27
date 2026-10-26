using UnityEngine;

// Prototipo de movimiento. Añade este script a un objeto con CharacterController.
[RequireComponent(typeof(CharacterController))]
public class AFC27PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.2f;
    public float turnSpeed = 540f;
    public Transform cameraTransform;
    public bool useTouchInput = true;

    private CharacterController controller;
    private Vector2 touchMove;
    private Vector2 touchStart;
    private int activeFinger = -1;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (Camera.main != null && cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (useTouchInput && Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                activeFinger = t.fingerId;
                touchStart = t.position;
            }
            if (t.fingerId == activeFinger &&
                (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary))
            {
                Vector2 delta = (t.position - touchStart) / 100f;
                touchMove = Vector2.ClampMagnitude(delta, 1f);
            }
            if (t.fingerId == activeFinger &&
                (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled))
            {
                touchMove = Vector2.zero;
                activeFinger = -1;
            }
            if (activeFinger >= 0) input = touchMove;
        }

        Vector3 forward = cameraTransform ? cameraTransform.forward : Vector3.forward;
        Vector3 right = cameraTransform ? cameraTransform.right : Vector3.right;
        forward.y = 0; right.y = 0;
        forward.Normalize(); right.Normalize();

        Vector3 move = forward * input.y + right * input.x;
        if (move.sqrMagnitude > 1f) move.Normalize();

        controller.Move(move * moveSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);

        if (move.sqrMagnitude > 0.01f)
        {
            Quaternion target = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, turnSpeed * Time.deltaTime);
        }
    }
}
