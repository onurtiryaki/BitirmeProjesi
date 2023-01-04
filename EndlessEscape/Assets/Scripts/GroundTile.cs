using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundSpawner;
    public GameObject coinPrefab;
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;

    private void Awake()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    void Start()
    {
        SpawnObs();
        SpawnCoin();
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawnGround();
        Destroy(gameObject,10f);
    }

    void Update()
    {
        
    }


    public void SpawnObs()
    {
        int chooseSpawnPoint = Random.Range(0,spawnPoints.Length);
        int spawnPrefab=Random.Range(0,obstaclePrefabs.Length);

        Instantiate(obstaclePrefabs[spawnPrefab], spawnPoints[chooseSpawnPoint].transform.position,Quaternion.identity,transform);
    }

    public void SpawnCoin()
    {
        int spawnAmount = 1;
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject tempCoin = Instantiate(coinPrefab);
            tempCoin.transform.position = SpawnRandomPoint(GetComponent < Collider>());
        }
    }

    Vector3 SpawnRandomPoint(Collider col)
    {
        Vector3 point = new Vector3(Random.Range(col.bounds.min.x,col.bounds.max.x ), Random.Range(col.bounds.min.y, col.bounds.max.y), Random.Range(col.bounds.min.z, col.bounds.max.z));
        point.y = 1;
        return point;
    }
}
