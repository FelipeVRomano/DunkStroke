using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlvo : MonoBehaviour
{
    [SerializeField]
    private Transform[] transPos;
    private int x;
    private int ultimoX;
    public static bool ativaCesta;
    private bool mudaCesta;
    [SerializeField]
    private float speed;
    // Update is called once per frame
    void Start()
    {
        ativaCesta = false;
    }
    void Update()
    {
      
      if (ativaCesta)
        {
            x = Random.Range(0, transPos.Length-1);
            if (x == ultimoX && x == transPos.Length-1) x -= 1;
            else if (x == ultimoX && x >= 0) x += 1;
            print(x);
            mudaCesta = true;
            ativaCesta = false;
        }

      if(mudaCesta)
        {
            ultimoX = x;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transPos[x].position, step);
            if(transform.position == transPos[x].position) mudaCesta = false;
        }
    }
}
