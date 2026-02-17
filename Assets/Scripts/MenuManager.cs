using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string GameSceneName = "MainGameScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GameSceneName);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
