using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject UnitPrefab;
    public int numberOfWaves;
    public int enemiesPerWave;
    public int secondsBetweenWaves;
    public int secondsStartDelay;
    public int pathId;
    public Transform destination;

    private int _currentWave = 0;

    private WaypointManager.Path _path;

    public void Init(WaypointManager.Path path)
    {
        _path = path;
    }

    public void StartSpawner()
    {
        StartCoroutine("BeginWaveSpawn");
    }

    private IEnumerator BeginWaveSpawn()
    {
        yield return new WaitForSeconds(secondsStartDelay);

        while(_currentWave < numberOfWaves)
        {
            yield return SpawnWave(_currentWave++);
            yield return new WaitForSeconds(secondsBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(int waveNumber)
    {
        for(int i = 0; i < enemiesPerWave; ++i)
        {
            GameObject unitGO = Instantiate(UnitPrefab, transform.position, Quaternion.LookRotation(destination.position));
            unitGO.GetComponent<Enemy>().waypoint = destination;
            yield return new WaitForSeconds(1f);
        }
    }
}
