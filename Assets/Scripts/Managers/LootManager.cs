using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public List<GameObject> allPossibleLoot = new List<GameObject>();

    public List<Transform> spawnLocations = new List<Transform>();

    public float lootScoreThreshold = 10f; 

    public float lootProgress;

    public static LootManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static void AddToThreshold(float points)
    {
        instance.lootProgress += points;

        if (instance.lootProgress >= instance.lootScoreThreshold)
        {
            instance.SpawnLoot();

           float difference = instance.lootProgress - instance.lootScoreThreshold;

            instance.lootProgress = difference; 


        }
    }

    public void ResetLootProgress()
    {
        lootProgress = 0;
    }

    public void SpawnLoot()
    {
        int lootIndex = Random.Range(0, allPossibleLoot.Count);

        int spawnIndex = Random.Range(0, spawnLocations.Count);

        Instantiate(allPossibleLoot[lootIndex], spawnLocations[spawnIndex].position, Quaternion.identity);
    }



}

