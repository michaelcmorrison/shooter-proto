using System.Collections;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject waveText;

    private void OnEnable()
    {
        EventManager.StartListening("WaveStarted", FlashWaveText);
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
