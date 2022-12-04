using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTweenController : MonoBehaviour
{
    public float Speed = 1f;
    public float Move = 10;

    private float _defaultPosition = 0.0f;
    private float _moveAmount = 0.0f;
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
        var move = Time.deltaTime * Speed;
        var prevPosition = _transform.position;

        _moveAmount += move;
        if (_isReversed)
            prevPosition.y += move * -1;
        else
            prevPosition.y += move;

        if (prevPosition.y >= _defaultPosition + Move)
            prevPosition.y = _defaultPosition;
        else if(prevPosition.y <= -_defaultPosition - Move)
            prevPosition.y = -_defaultPosition;
       
        //Debug.Log(_moveAmount + "//" + prevPosition);
        _transform.position = prevPosition;

        if (_moveAmount >= Move)
        {
            _isReversed = !_isReversed;
            _moveAmount = 0;
        }
    }
}
