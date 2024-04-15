using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float smoothing = 5f;
    [SerializeField] private Vector2 range = new(100, 100);

    private Vector3 _targetPosition;
    private Vector3 _input;

    private void Awake()
    {
        _targetPosition = transform.position;
    }


    private void HandleInput()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

        Vector3 right = transform.right * x;
        Vector3 forward = transform.forward * z;

        _input = (forward + right).normalized;
    }

    private void Move()
    {
        Vector3 nextTargetPosition = _targetPosition + _input * speed;
        if (IsInBound(nextTargetPosition)) _targetPosition = nextTargetPosition;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _smoothing);
    }

    private bool IsInBound(Vector3 position)
    {
        return position.x > -range.x &&
               position.x < range.x &&
               position.z > -range.y &&
               position.z < range.y;
    }

    private void Update()
    {
        HandleInput();
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,5f);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(range.x*2f,5f,range.y*2f));
    }
}
