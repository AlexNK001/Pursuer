using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _first;
    [SerializeField] private float _torque;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _first.AddTorque(transform.forward * _torque);
    }
}
