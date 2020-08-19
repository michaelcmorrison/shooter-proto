using TMPro;
using UnityEngine;

// ReSharper disable once InconsistentNaming
public class WaveTextUI : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private TMP_Text text;

    private void Update()
    {
        text.text = "Wave " + waveManager.GetCurrentWave();
    }
}
