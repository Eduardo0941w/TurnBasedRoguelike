using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public enum PlayerState
    {
        Idle,
        Move,
        Attack,
        Rest
    }

    public PlayerState currentState;

    private void Update()
    {
        if (!GameManager.Instance.CanPlayerMove())
            return;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y);

        if (direction.magnitude > 1)
        {
            direction = direction.normalized;
            currentState = PlayerState.Move;
        }
        else
        {
            currentState = PlayerState.Idle;
        }

        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}