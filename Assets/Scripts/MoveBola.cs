using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveBola : MonoBehaviour
{
    private Rigidbody bola;

    private bool moveDir, moveEsq;

    [SerializeField]
    private Vector2 ballForce,ballForce2;
    Camera mainCamera;

    private bool cond1, cond2;
    private bool outroBool;
    int ctrl;

    private bool ficouParadaDir;
    private bool ficouParadaEsq;
    private float timer;
    [SerializeField]
    private Text pontText;

    [SerializeField]
    private Vector3 trans;

    [SerializeField]
    private Vector3 trans2;
    void Start()
    {
        bola = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        ctrl = 0;
        pontText.text = ctrl.ToString();
        moveDir = true;
    }


    void Update()
    { 
        if (cond1 && cond2)
        {
            outroBool = true;
            BarraDeTempo.pontuou = true;
            ctrl++;
            pontText.text = ctrl.ToString();
            if (ctrl > 1)
            BarraDeTempo.contraFi = true;
            MoveAlvo.ativaCesta = true;
            cond1 = false;
            cond2 = false;
        }

        if(outroBool)
        {
            if(moveDir)
            {
                moveEsq = true;
                moveDir = false;
            }
            else if(moveEsq)
            {
                moveDir = true;
                moveEsq = false;
            }
            outroBool = false;
        }
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
        if (Input.GetMouseButtonDown(0) && moveDir)
        {
            if (bola.isKinematic) bola.isKinematic = false;
            bola.velocity = Vector2.zero;
            bola.AddForce(ballForce, ForceMode.Impulse);
        }
        else if(Input.GetMouseButtonDown(0) && moveEsq)
        {
            if (bola.isKinematic) bola.isKinematic = false;
            bola.velocity = Vector2.zero;
            bola.AddForce(ballForce2, ForceMode.Impulse);
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("box1"))
        {
            if (cond2) cond2 = false;
            cond1 = true;
        }

        if (other.CompareTag("box2"))
        {
            cond2 = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("box1"))
            cond1 = false;

        if (other.CompareTag("box2"))
            cond2 = false;
    }

   
}
