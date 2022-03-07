using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UnityEvent OnPlayGame;
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        OnPlayGame.Invoke();
    }
}
