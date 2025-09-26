using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 4f;
    public bool fourDirection = true;

    Rigidbody2D rb;
    Vector2 input;
    public Vector2 Facing { get; private set; } = Vector2.down;

    void Awake() { rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.sqrMagnitude > 1f) input.Normalize();

        if (input.sqrMagnitude > 0.01f)
        {
            if (fourDirection)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) Facing = new Vector2(Mathf.Sign(input.x), 0);
                else Facing = new Vector2(0, Mathf.Sign(input.y));
            }
            else Facing = input.normalized;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    public Vector2 GetInput() => input;
}

