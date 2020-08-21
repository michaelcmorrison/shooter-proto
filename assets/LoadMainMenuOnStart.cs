using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenuOnStart : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
