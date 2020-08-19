using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipPanel : MonoBehaviour
{
    private Image _shipImage;
    private TMP_Text _shipDescription;

    private void Awake()
    {
        _shipImage = GetComponentInChildren<Image>();
        _shipDescription = GetComponentInChildren<TMP_Text>();
    }

    public void SetPanelContents(Sprite shipSprite, string shipDescription)
    {
        _shipImage.sprite = shipSprite;
        _shipDescription.text = shipDescription;
    }
    
}
