using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    [Header("HORIZONTAL")]
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _horizontalLimit;
    private float _horizontal;
    [Header("SPEED")]
    [SerializeField] private float _moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        HorizontalBallMove();
        BallMover();
    }

    private void HorizontalBallMove()
    {
        float _newX;
        
        
        if(Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }

        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

        transform.position = new Vector3(_newX, transform.position.y, transform.position.z);
    }
    
    private void BallMover(){
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}
