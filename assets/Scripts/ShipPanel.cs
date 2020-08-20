using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShipPanel : MonoBehaviour
{
    private ShipSelector _shipSelector;
    private Image _shipImage;
    private TMP_Text _shipDescription;
    private Button _button;
    private string _shipName;

    private UnityAction _onButtonClick;

    private void Awake()
    {
        _shipSelector = GetComponentInParent<ShipSelector>();
        _shipImage = GetComponentInChildren<Image>();
        _shipDescription = GetComponentInChildren<TMP_Text>();
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _onButtonClick += SubmitToSelector;
        _button.onClick.AddListener(_onButtonClick);
    }

    public void SetPanelContents(string shipName, Sprite shipSprite, string shipDescription)
    {
        _shipName = shipName;
        _shipImage.sprite = shipSprite;
        _shipDescription.text = shipDescription;
    }

    private void SubmitToSelector()
    {
        _shipSelector.SetSelectedShip(_shipName);
    }
}
