using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnIndicatorPrefab;
    [SerializeField] private int indicatorDelay;

    [SerializeField] private Transform[] spawnLocations;

    public IEnumerator SpawnEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var spawnLocation = spawnLocations[i % spawnLocations.Length];
            StartCoroutine(SpawnEnemy(spawnLocation));
            yield return new WaitForSeconds(.5f);
        }
    }

    private IEnumerator SpawnEnemy(Transform location)
    {
        var spawnIndicator = Instantiate(spawnIndicatorPrefab, location);
        yield return new WaitForSeconds(indicatorDelay);
        Destroy(spawnIndicator);
        Instantiate(enemyPrefab, location);
    }
}
