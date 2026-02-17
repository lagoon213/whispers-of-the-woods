using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenManager : MonoBehaviour
{

    [SerializeField] private string MainMenuSceneName = "MainMenuGameScene";
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject pauseScreen;

    private Canvas pauseCanvas;

    void Awake()
    {
        pauseCanvas = pauseScreen.GetComponentInChildren<Canvas>();
        pauseCanvas.gameObject.SetActive(false);
    }

    public void TriggerPause()
    {
        pauseCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        crosshair.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }
}
