using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool _gameStarted;

    public bool GameStarted => _gameStarted;

    private void Start()
    {
        _gameStarted = true;
    }

    public void ChangeGameStatus()
    {
        if (_gameStarted == true)
        {
            _gameStarted = false;
        }
        else
        {
            _gameStarted = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
