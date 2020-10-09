using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeTempo : MonoBehaviour
{
    Image timerBar;
    [SerializeField]
    private float maxTime = 8f;
    public float timeLeft;
    public static bool pontuou;

    public static bool contraFi;
    [SerializeField]
    private GameObject endGame;

    void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {

        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        pontuou = false;
        contraFi = false;
    }

    void Update()
    {
        if (contraFi)
        {
            timeLeft = 8f;
            timerBar.fillAmount = 1f;
            contraFi = false;
        }
        if (pontuou && timeLeft>0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else if(pontuou && timeLeft <=0)
        {
            endGame.SetActive(true);
            Time.timeScale = 0;
            pontuou = false;
        }
        
    }
}
