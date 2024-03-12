using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTweenController : MonoBehaviour
{
    public float Speed = 1f;
    public float Length = 1;

    [SerializeField] private Transform _target = null;

    private bool _isReverse = false;
    float moveAmount = 0.0f;

    void Update()
    {
        var moveDelta = Time.deltaTime * Speed;
        var direction = transform.up;
        
        // 바라보는 상대가 있으면 방향은 상대방이다.
        if (_target != null)
        {
            transform.LookAt(_target);
            direction = _target.position - transform.position;
        }

        var move = direction * moveDelta;
        moveAmount += move.magnitude;

        Vector3 updatePosition = Vector3.zero;
        if (_isReverse)
            updatePosition = transform.position + direction * moveDelta * -1;
        else
            updatePosition = transform.position + direction * moveDelta;

        if (moveAmount >= Length)
        {
            _isReverse = !_isReverse;
            moveAmount = 0.0f;
        }
        transform.position = updatePosition;
    }
}
