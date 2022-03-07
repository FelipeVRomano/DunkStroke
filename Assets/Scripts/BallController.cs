using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{
    public event Action OnScorePoint;
    
    [SerializeField] Text _pointText;
    [SerializeField] Vector2 _ballForce;
    
    private Rigidbody _rigidbody;
    Camera mainCamera;
    private bool _moveLeft;
    private bool _upperBox, _lowerBox;
    private int _pointsCount;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        _pointsCount = 0;
        _pointText.text = _pointsCount.ToString();
        _moveLeft = false;
    }
    
    void Update()
    {
        ScoreCheck();
        KeepBallOnScreen();
        MoveBall();
    }

    void ScoreCheck()
    {
        if (_upperBox && _lowerBox)
        {
            _moveLeft = !_moveLeft;
            OnScorePoint?.Invoke();

            _pointsCount++;
            _pointText.text = _pointsCount.ToString();

            _upperBox = false;
            _lowerBox = false;
        }
    }
    
    void KeepBallOnScreen()
    {
        if (transform.position.z != 0f) transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        if (mainCamera.WorldToViewportPoint(transform.position).x < -0.2f)
        {
            transform.position = new Vector3(3.4f, transform.position.y, 0f);       
        }
        if (mainCamera.WorldToViewportPoint(transform.position).x > 1.1f)
        {
            transform.position = new Vector3(-3.9f, transform.position.y, 0f);
        }
        if (mainCamera.WorldToViewportPoint(transform.position).y > 1.2f)
        { 
            transform.position = new Vector3(transform.position.x, 7.5f, 0f);
        }
    }
    
    void MoveBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_rigidbody.isKinematic) _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector2.zero;
            
            if(!_moveLeft)
            _rigidbody.AddForce(_ballForce, ForceMode.Impulse);
            else
            {
                _rigidbody.AddForce(new Vector3(-_ballForce.x, _ballForce.y, 0), ForceMode.Impulse);
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UpperBox"))
        {
            if (_lowerBox) _lowerBox = false;
            _upperBox = true;
        }

        if (other.CompareTag("LowerBox"))
        {
            _lowerBox = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UpperBox"))
        {
            _upperBox = false;
        }

        if (other.CompareTag("LowerBox"))
            _lowerBox = false;
    }
}