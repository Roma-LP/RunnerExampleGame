using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;  
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0f;
    }

    private void OnDied()
    {
        _gameOverGroup.alpha = 1f;
        Time.timeScale = 0;
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}