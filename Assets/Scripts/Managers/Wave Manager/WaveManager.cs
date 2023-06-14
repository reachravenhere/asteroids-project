using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
   public List<Wave> waves = new List<Wave>();


    public int nextWave;


    public void SpawnWave(int waveIndex, Vector2 spawnLocation)


    {
        if (waveIndex >= waves.Count) {

            //Debug.LogError("There are not:" + waveIndex + "waves in the wave manager. Index out of range");
            PanelManager.OpenPanel<EndGamePanel>().Setup(false);
            return;
        }

        //PanelManager.OpenPanel<BroadcastPanel>().ShowMessage("WAVE " + (nextWave + 1).ToString());
        waves[waveIndex].SpawnWave(spawnLocation);
        nextWave++;

    }

    public void ResetWaves()
    {
        nextWave = 0;
    }
}
