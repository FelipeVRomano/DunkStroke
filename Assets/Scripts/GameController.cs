using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ativa;
    [SerializeField]
    private GameObject[] desAtiva;
    public void reload()
    {
        SceneManager.LoadScene(0);
    }

    public void saiMenu()
    {
        for(int i = 0; i < ativa.Length; i++)
        {
            ativa[i].SetActive(true);
        }
        for (int i = 0; i < desAtiva.Length; i++)
        {
            desAtiva[i].SetActive(false);
        }
    }
   
}
