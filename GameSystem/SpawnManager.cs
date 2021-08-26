using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnManager : Singleton<SpawnManager>
{
    public List<Transform> spawnPoint = new List<Transform>();
    public List<GameObject> spawnPrefabs = new List<GameObject>();

    public void Spawn(int spawnPrefabIndex)
    {
        Spawn(spawnPrefabIndex, 0);
    }

    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {
        Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
    }

}
