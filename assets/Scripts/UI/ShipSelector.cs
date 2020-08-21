using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelector : MonoBehaviour
{
    [SerializeField] private GameObject shipPanelPrefab;

    private List<GameObject> _ships;

    private void Start()
    {
        _ships = ShipPrefabLookup.Instance.GetShips();
        ShowShipOptions();
    }

    private void ShowShipOptions()
    {
        foreach (var ship in _ships)
        {
            var shipGo = Instantiate(ship);
            if (shipGo.TryGetComponent(out ShipInfo shipInfo))
            {
                Destroy(shipGo);

                var panelGo = Instantiate(shipPanelPrefab, transform);

                if (panelGo.TryGetComponent(out ShipPanel shipPanel))
                {
                    shipPanel.SetPanelContents(ship.name, shipInfo.GetShipImage(), shipInfo.GetShipInfo());
                }
            }
        }
    }

    public void SetSelectedShip(string shipName)
    {
        foreach (var ship in _ships)
        {
            if (ship.name == shipName)
            {
                GameSettings.Instance.SetSelectedShip(ship);
                EventManager.InvokeEvent("ShipSelected");
            }
        }
    }

}
