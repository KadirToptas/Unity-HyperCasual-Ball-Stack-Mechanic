using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    private Vector3 _offset;
    [SerializeField] private float _lerpTime;
    void Start()
    {
        _offset = transform.position - _ballTransform.position;
    }

    void LateUpdate()
    {
        Vector3 _newPos = Vector3.Lerp(transform.position, _ballTransform.position + _offset,
            _lerpTime * Time.deltaTime);

        transform.position = _newPos;
    }
    
}
