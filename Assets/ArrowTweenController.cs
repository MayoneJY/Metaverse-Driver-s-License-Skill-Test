using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTweenController : MonoBehaviour
{
    public float Speed = 1f;
    public float Move = 10;

    private float _defaultPosition = 0.0f;
    private bool _isReversed = false;

    private Transform _transform = null;

    private void Awake()
    {
        if (_transform == null)
            _transform = gameObject.transform;

        _defaultPosition = _transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var moveDelta = Time.deltaTime * Speed;
        var updatePosition = _transform.position;

        if (_isReversed)
            updatePosition.y += moveDelta * -1;
        else
            updatePosition.y += moveDelta;

        bool isTrigger = false;
        if (updatePosition.y >= _defaultPosition + Move)
        {
            updatePosition.y = _defaultPosition + Move;
            isTrigger = true;
        }
        else if(updatePosition.y <= _defaultPosition - Move)
        {
            updatePosition.y = _defaultPosition - Move;
            isTrigger = true;
        }
       
        _transform.position = updatePosition;

        if (isTrigger)
            _isReversed = !_isReversed;
    }
}
