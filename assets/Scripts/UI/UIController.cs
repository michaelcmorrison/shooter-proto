using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject waveText;
    [SerializeField] private GameObject pauseMenu;

    private void OnEnable()
    {
        EventManager.StartListening("WaveStarted", FlashWaveText);
        EventManager.StartListening("GamePaused", ShowPauseMenu);
        EventManager.StartListening("GameUnpaused", HidePauseMenu);
    }

    private void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    private void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }


    private void OnDisable()
    {
        EventManager.StopListening("WaveStarted", FlashWaveText);
    }

    private void FlashWaveText()
    {
        StartCoroutine(FlashUiElement(waveText));
    }

    private IEnumerator FlashUiElement(GameObject toFlash)
    {
        toFlash.SetActive(true);
        yield return new WaitForSeconds(2);
        toFlash.SetActive(false);
    }
}
