using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Wave
{
    //public List<Asteroid> asteroids = new List<Asteroid>();
    
    public List<WaveEntry> waveEntries = new List<WaveEntry>();

    public void SpawnWave(Vector2 spawnLocation)
    {
        for (int i = 0; i < waveEntries.Count; i++)
        {
            waveEntries[i].Spawn(spawnLocation);
        }
    }

}
[System.Serializable]
public class WaveEntry
{
    public int count;
    public Asteroid asteroid;

    public void Spawn(Vector2 spawnLocation)
    {
      for (int i = 0; i < count; i++)
        {
            GameObject.Instantiate(asteroid, spawnLocation, Quaternion.identity);
        }
    }

}