using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildThrowObjects : MonoBehaviour
{
    [SerializeField] GameObject[] prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxYDistance = 0.5f;
    [SerializeField] private Transform objectsOfLevel;
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true && this.enabled)
        {
            
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y + maxYDistance,
                transform.position.z + Random.Range(-maxXDistance, +maxXDistance));
            if(this.enabled)
            {
                GameObject newObject = Instantiate(prefabToSpawn[Random.Range(0, prefabToSpawn.Length)].gameObject, positionOfSpawnedObject, Quaternion.identity);
                newObject.transform.parent = objectsOfLevel;
            }
            
            
        }
    }
}
