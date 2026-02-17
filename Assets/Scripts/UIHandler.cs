using UnityEngine;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    private PauseScreenManager pauseScreen;
    private bool isPaused;

    void Start()
    {
        pauseScreen = FindAnyObjectByType<PauseScreenManager>(FindObjectsInactive.Include);
    }


    public void OnPause(InputAction.CallbackContext value)
    {
        if (!value.started) return;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseScreen.ResumeGame();
            isPaused = false;
        }
        else
        {
            pauseScreen.TriggerPause();
            isPaused = true;
        }
    }
}
