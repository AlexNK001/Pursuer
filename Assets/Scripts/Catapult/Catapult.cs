using System;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    private const KeyCode FireButton = KeyCode.W;

    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Rigidbody _connectetBody;
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField, Min(0f)] private float _fireSpring;
    [SerializeField, Min(0f)] private float _reloadSpring;
    [SerializeField] private Point _startPoint;
    [SerializeField] private Point _endPoint;
    [SerializeField] private GameObject _lever;
    [SerializeField] private ProjectileStorage ProjectileStorage;
    [SerializeField] private float _digit = 1f;

    private bool _isReady;
    private float _minStartPointAngle;
    private float _maxStartPointAngle;
    private float _minEndPointAngle;
    private float _maxEndPointAngle;

    private void Awake()
    {
        ChangePoint(_startPoint, _reloadSpring);
      
        _minStartPointAngle = _hingeJoint.limits.min - _digit;
        _maxStartPointAngle = _hingeJoint.limits.min + _digit;
        _minEndPointAngle = _hingeJoint.limits.max - _digit;
        _maxEndPointAngle = _hingeJoint.limits.max + _digit;
    }

    private void Update()
    {
        float angles = _lever.transform.rotation.eulerAngles.z;

        if (_isReady == true && Input.GetKeyDown(FireButton))
        {
            _isReady = false;
            ChangePoint(_endPoint, _fireSpring);
        }
        else if (_isReady == false && angles > _minStartPointAngle && angles < _maxStartPointAngle)
        {
            _isReady = true;
            ProjectileStorage.Spawn();
        }
        else if (angles > _minEndPointAngle && angles < _maxEndPointAngle)
        {
            ChangePoint(_startPoint, _reloadSpring);
        }
    }

    private void ChangePoint(Point point, float spring)
    {
        _connectetBody.transform.position = point.transform.position;
        _springJoint.spring = spring;
    }
}
