using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public WaypointManager waypointManager;
    public SpawnManager spawnManager;
    public Text goldText;
    public static float scoreGold;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        scoreGold++;
    }

    
    void Update()
    {
        goldText.text = "Gold:" + scoreGold;
        if(Input.GetKey("f"))
        {
            scoreGold++;
        }
    }
    public static void AddScore(float amount)
    {
        scoreGold += amount;
        Debug.Log("Click on coin");
    }


    public void BeginWave()
    {
        if (spawnManager != null && waypointManager.Paths.Count > 0)
        {
            spawnManager.Initialize(waypointManager);
            spawnManager.StartSpawners();
        }
        else
        {
            Debug.Log("Fail to start the initailization.");
        }
    }

}
