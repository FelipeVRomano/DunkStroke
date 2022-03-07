using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeBar : MonoBehaviour
{
    [SerializeField] float maxTime = 8f;
    [SerializeField] UnityEvent OnEndGame;

    private BallController _ballController;
    private float _timeLeft;
    bool _canCount;
    Image _timerBar;

    private void Awake()
    {
        _ballController = FindObjectOfType<BallController>();
    }

    void Start()
    {
        Time.timeScale = 1;
        _timerBar = GetComponent<Image>();
        _timeLeft = maxTime;
        _canCount = false;
    }
    
    void OnEnable()
    {
        _ballController.OnScorePoint += ResetTimer;
    }

    void OnDisable()
    {
        _ballController.OnScorePoint -= ResetTimer;
    }
    
    void Update()
    {
        TimeBarHandler();
    }

    void TimeBarHandler()
    {
        if (_canCount)
        {
            if (_timeLeft < 0)
            {
                OnEndGame.Invoke();
                Time.timeScale = 0;
                _canCount = false;
            }
            _timeLeft -= Time.deltaTime;
            _timerBar.fillAmount = _timeLeft / maxTime;
        }
    }
    
    void ResetTimer()
    {
        _timeLeft = 8f;
        _timerBar.fillAmount = 1f;

        _canCount = true;
    }
}
