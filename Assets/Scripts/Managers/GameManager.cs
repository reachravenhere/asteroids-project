using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player playerPrefab;
    //public Asteroid asteroidPrefab;
    //public List<Asteroid> asteroidList = new List<Asteroid>();
    public WaveManager waveManager;
    //public int startingAsteroidCount = 3;
    public Transform asteroidSpawnLocation;


    public static GameManager gameManagerInstance;

    public static List<NPC> activeNPCs = new List<NPC>();

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }

        

    }
    private void Start()
    {
        SpawnEnemies(1);
    }
    public static void RegisterEnemy(NPC target)
    {
        if (activeNPCs.Contains(target) == false)
        {
            activeNPCs.Add(target);
        }
    }

    public static void UnregisterEnemy(NPC target)
    {
        if (activeNPCs.Contains(target) == true)
        {
            activeNPCs.Remove(target);

        }

        if (activeNPCs.Count == 0)
        {

            gameManagerInstance.StartCoroutine(gameManagerInstance.SpawnNextWaveOnDelay());



        }
    }

    private IEnumerator SpawnNextWaveOnDelay()
    {

        WaitForSeconds waiter = new WaitForSeconds(2f);

        PanelManager.OpenPanel<BroadcastPanel>().ShowMessage("WAVE " +
            (gameManagerInstance.waveManager.nextWave +1). ToString(), 2f);



        yield return waiter;

        gameManagerInstance.waveManager.SpawnWave(
                gameManagerInstance.waveManager.nextWave,
                gameManagerInstance.asteroidSpawnLocation.position);

    }

    public void StartGame()
    {

        

        SpawnOrResetPlayer();
        ResetGame();


        //SpawnEnemies();

        StartCoroutine(SpawnNextWaveOnDelay());





    }

    public void ResetGame()
    {
        waveManager.ResetWaves();
        RemoveAllEnemies();
        FindAnyObjectByType<HUD>().ResetScore();
    }

    private void SpawnOrResetPlayer()
    {
        if (Player.playerInstance == null)
        {//create player using  0,0 xy coord and default rotation
            Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
        }
        else
        {
            Player.playerInstance.transform.position = Vector2.zero;
        }
    }

    private void SpawnEnemies(int waveOverride = 0)
    {
       
        waveManager.SpawnWave(waveOverride, asteroidSpawnLocation.position);




        //int count;

        //if (enemyOverride >0)
        //{
        //    count = enemyOverride;
        //}
        //else
        //{
        //    count = startingAsteroidCount;
        //}


        //for (int i = 0; i < count; i++)
        //{
        //    int randomIndex = Random.Range(0, asteroidList.Count);

        //    Instantiate(asteroidList[randomIndex], asteroidSpawnLocation.position, Quaternion.identity);
        //}
    }

    public void RemoveAllEnemies()
    {


        for (int i = activeNPCs.Count - 1; i >= 0; i--)
        {
            Destroy(activeNPCs[i].gameObject);
            //UnregisterEnemy(activeAsteroids[i]);

        }
        activeNPCs.Clear();
    }

}
