using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
   public GameObject groundPrefab;
   Vector3 nextSpawnPoint;

    public void spawnGround()
    {
        GameObject tempGround=Instantiate(groundPrefab,nextSpawnPoint,Quaternion.identity);
        nextSpawnPoint=tempGround.transform.GetChild(0).transform.position;
    }


    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnGround(); 
        }
   
    }
}
