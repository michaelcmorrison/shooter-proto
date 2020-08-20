using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> ships;
    [SerializeField] private GameObject shipPanelPrefab;
    private GameObject _selectedShip;

    private void Start()
    {
        ShowShipOptions();
    }

    private void ShowShipOptions()
    {
        foreach (var ship in ships)
        {
            if (ship == null) return;

            var shipGo = Instantiate(ship, transform);

            if (shipGo.TryGetComponent(out ShipInfo shipInfo))
            {
                Destroy(shipGo);
                var panelGo = Instantiate(shipPanelPrefab, transform);

                if (panelGo.TryGetComponent(out ShipPanel shipPanel))
                {
                    shipPanel.SetPanelContents(shipInfo.ShipName, shipInfo.GetShipImage(), shipInfo.GetShipInfo());
                }
            }
        }
    }

    public void SetSelectedShip(string shipName)
    {
        Debug.Log(shipName);
        foreach (var ship in ships)
        {
            if (ship.name == shipName)
            {
                _selectedShip = ship;
                EventManager.InvokeEvent("ShipSelected");
                Debug.Log(_selectedShip);
            }
        }
    }

    public GameObject GetSelectedShip() => _selectedShip != null ? _selectedShip : throw new UnityException("No ship selected");

    public void SpawnSelectedShip()
    {
        var go = Instantiate(GetSelectedShip());
        go.AddComponent<DontDestroyOnLoad>();
    }
}
