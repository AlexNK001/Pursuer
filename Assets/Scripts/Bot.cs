using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Player _target;
    [SerializeField, Min(0f)] private float _speed;
    [SerializeField, Min(0f)] private float _distabce;

    private void Start()
    {
        _distabce *= _distabce;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = _target.transform.position - transform.position;

        if (moveDirection.sqrMagnitude > _distabce)
        {
            moveDirection = _speed * moveDirection.normalized;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        _rigidbody.velocity = moveDirection + Vector3.down;
    }
}
