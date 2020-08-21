using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool Paused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (Paused)
        {
            Time.timeScale = 1;
            EventManager.InvokeEvent("GameUnpaused");
            Paused = false;
        }
        else
        {
            Time.timeScale = 0;
            EventManager.InvokeEvent("GamePaused");
            Paused = true;
        }
    }
}
