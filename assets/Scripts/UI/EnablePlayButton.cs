using UnityEngine;

public class EnablePlayButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    private void OnEnable()
    {
        EventManager.StartListening("ShipSelected", EnableButton);
    }

    public void EnableButton()
    {
        button.SetActive(true);
    }
}
