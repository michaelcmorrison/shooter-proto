using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    private static GameSettings _instance;
    public static GameSettings Instance => _instance;

    private GameObject _selectedShip;

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
    }

    public void SetSelectedShip(GameObject selectedShip)
    {
        _selectedShip = selectedShip;
    }

    public GameObject GetSelectedShip()
    {
        return _selectedShip;
    }

}
