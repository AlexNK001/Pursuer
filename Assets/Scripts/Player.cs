using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private CharacterController _characterController;
    [SerializeField, Min(0f)] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection;

        if (_characterController.isGrounded)
        {
            moveDirection = new(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
            moveDirection *= _speed * Time.deltaTime;
            moveDirection += Vector3.down;
        }
        else
        {
            moveDirection = _characterController.velocity + Physics.gravity * Time.deltaTime;
        }

        _characterController.Move(moveDirection);
    }
}
