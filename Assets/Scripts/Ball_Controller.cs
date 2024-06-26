using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Ball_Controller : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    
    private int _gateNumber;

    private int _targetCount;
    
    [Header("TEXT")]
    [SerializeField] private TMP_Text _ballCountText;
    
    [Header("BALL_LIST")]
    
    [SerializeField] private List<GameObject> _balls = new List<GameObject>();
    
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
        UpdateBallCountText();
    }

    private void HorizontalBallMove()
    {
        float _newX;
        
        
        if(Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            _horizontal = 0f;
        }

        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

        transform.position = new Vector3(_newX, transform.position.y, transform.position.z);
    }
    
    private void BallMover(){
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stack"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z -1f);
            _balls.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            _gateNumber = other.gameObject.GetComponent<Gate_Controller>().GetGateNumber();
            _targetCount = _balls.Count + _gateNumber;


            if (_gateNumber > 0)
            {
              IncreaseBallCount();  
            }
            else if(_gateNumber <0){
                DecreaseBallCount();
            }
        }
    }

    private void IncreaseBallCount()
    {
        for (int i = 0; i < _gateNumber; i++)
        {
            GameObject _newBall =Instantiate(_ballPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<SphereCollider>().enabled = false;
            _newBall.gameObject.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z -1f);
            _balls.Add(_newBall);
 
        }
    }

    private void DecreaseBallCount()
    {
        for (int i = _balls.Count-1 ; i >= _targetCount; i--)
        {
            _balls[i].SetActive(false);
            _balls.RemoveAt(i);
            
        }
    }

    private void UpdateBallCountText()
    {
        _ballCountText.text = _balls.Count.ToString();
    }
}
