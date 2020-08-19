using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject planetBase;
    [SerializeField] private List<Sprite> planetSprites;
    private Transform[] _spawnLocations;


    private void Awake()
    {
        _spawnLocations = GetComponentsInChildren<Transform>();
    }

    private void Start()
    {
        SpawnPlanets();
    }

    private void SpawnPlanet()
    {
        var planet = Instantiate(planetBase, _spawnLocations[Random.Range(0, _spawnLocations.Length)]);
        planet.transform.position += new Vector3(0,0,10);
        planet.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count)];
    }

    private void SpawnPlanets()
    {
        for (int i = 0; i < _spawnLocations.Length; i++)
        {
            var planet = Instantiate(planetBase, _spawnLocations[i]);
            planet.GetComponent<SpriteRenderer>().sprite = planetSprites[Random.Range(0, planetSprites.Count)];
        }
    }
}
