using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private Transform _lookAt;
    [SerializeField] private Transform _followTransform;
    [SerializeField] private float _followSpeed;

    private Transform _thisTransform;

    void Start()
    {
        _thisTransform = transform;
    }

    void Update()
    {
        _followTransform.LookAt(_lookAt, Vector3.up);

        var newPosition = _thisTransform.position;
        var followPosition = _followTransform.position;

        newPosition.x = Mathf.Lerp(newPosition.x, followPosition.x, _followSpeed * Time.deltaTime);
        newPosition.y = Mathf.Lerp(newPosition.y, followPosition.y, _followSpeed * Time.deltaTime);
        newPosition.z = Mathf.Lerp(newPosition.z, followPosition.z, _followSpeed * Time.deltaTime);

        transform.position = newPosition;
        transform.rotation = _lookAt.rotation;
    }
}
