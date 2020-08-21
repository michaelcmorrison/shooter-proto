using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject _gameObjectToSpawn;

    private void Awake()
    {
        _gameObjectToSpawn = GameSettings.Instance.GetSelectedShip();
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(_gameObjectToSpawn);
        EventManager.InvokeEvent("PlayerSpawned");
    }
}
