using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetController : MonoBehaviour
{
    [Header("Target Manager")]
    [SerializeField] Transform[] _targetPositions;
    [SerializeField] float _targetSpeed;
    
    private List<Transform> _availablePositions = new List<Transform>();
    private bool _canMove;
    private Transform _actualPosition;
    private Transform _lastPosition;

    private BallController _ballController;
    void Awake()
    {
        _availablePositions = _targetPositions.ToList();
        _ballController = FindObjectOfType<BallController>();
    }

    void OnEnable()
    {
        _ballController.OnScorePoint += ChooseTarget;
    }

    void OnDisable()
    {
        _ballController.OnScorePoint -= ChooseTarget;
    }

    void Update()
    {
        MoveTarget();
    }
    
    public void ChooseTarget()
    {
        var randomIndex = Random.Range(0, _availablePositions.Count - 1);
        _actualPosition = _availablePositions[randomIndex];
        
        _availablePositions.Remove(_actualPosition);
        
        if(_lastPosition != null)
            _availablePositions.Add(_lastPosition);
        _lastPosition = _actualPosition;
        
        _canMove = true;
    }
    
    void MoveTarget()
    {
        if (_canMove)
        {
            float step = _targetSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _actualPosition.position, step);
            if (transform.position == _actualPosition.position) _canMove = false;
        }
    }
}
