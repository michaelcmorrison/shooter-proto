using System;
using System.Collections;
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
                    shipPanel.SetPanelContents(shipInfo.GetShipImage(), shipInfo.GetShipInfo());
                }
            }
        }
    }
}
