using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private TrailRenderer _trail;

    private void OnEnable()
    {
        _trail.emitting = true;
        _rigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        _trail.Clear();
    }
}
