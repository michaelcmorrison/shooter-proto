using System.Collections.Generic;
using UnityEngine;

public class ShipInfo : MonoBehaviour
{
    private Sprite _shipImage;
    private Ship _ship;
    private PlayerMover _mover;
    private Blaster _blaster;

    public Dictionary<string, string> shipInfo;

    private void Awake()
    {
        _shipImage = GetComponent<SpriteRenderer>().sprite;
        _ship = GetComponent<Ship>();
        _mover = GetComponent<PlayerMover>();
        _blaster = GetComponent<Blaster>();

        shipInfo = BuildShipInfo();
    }

    private Dictionary<string, string> BuildShipInfo()
    {
        var dictToReturn = new Dictionary<string, string>();

        dictToReturn.Add("Ship", _ship.GetAttributes().description);
        dictToReturn.Add("Mover", _mover.GetAttributes().description);
        dictToReturn.Add("Blaster", _blaster.GetAttributes().description);

        return dictToReturn;
    }

    public Sprite GetShipImage()
    {
        return _shipImage;
    }

    public string GetShipInfo()
    {
        return $"Ship Description:{GetPartDescription("Ship")}\n" +
               $"Mover Description: {GetPartDescription("Mover")}\n" +
               $"Blaster Description: {GetPartDescription("Blaster")}";
    }

    private string GetPartDescription(string part)
    {
        return shipInfo[part];
    }
}
