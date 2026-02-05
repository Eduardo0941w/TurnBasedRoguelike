using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool canMove = true;

    void Update()
    {
        if (!canMove) return;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(x, y);

        if (move.magnitude > 1f)
        {
            move = move.normalized;
        }

        Vector3 displacement = (Vector3)(move * speed * Time.deltaTime);

        transform.position += displacement;
    }
}