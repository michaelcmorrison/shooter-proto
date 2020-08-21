using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipPrefabLookup : MonoBehaviour
{
    [SerializeField] private List<GameObject> shipPrefabs;
    private Dictionary<string, GameObject> _shipDictionary;

    private static ShipPrefabLookup _instance;
    public static ShipPrefabLookup Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        _shipDictionary = BuildShipDictionary();
    }

    private Dictionary<string, GameObject> BuildShipDictionary()
    {
        var dictToReturn = new Dictionary<string, GameObject>();

        foreach (var ship in shipPrefabs)
        {
            dictToReturn.Add(ship.gameObject.name, ship);
        }

        return dictToReturn;
    }

    public GameObject LookupShip(string shipName)
    {
        return _shipDictionary[shipName];
    }

    public List<GameObject> GetShips()
    {
        return shipPrefabs;
    }
}
