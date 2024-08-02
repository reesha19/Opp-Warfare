using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Activate : MonoBehaviour
{
    public GameObject[] enemies; // Array to hold different enemy prefabs
    public Transform[] spawnPoints; // Array to hold different spawn points
    public float spawnInterval = 60f; // Interval between spawns
    public AudioSource first_Sound; // Reference to the sound clip for a single enemy
    public AudioSource Second_Sound; 
    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 40f, spawnInterval);
    }

    private void SpawnEnemies()
    {
        
        for (int i = 0; i < 3; i++)
        {
            int enemyIndex = Random.Range(0, enemies.Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
          
        }
      
        StartCoroutine(ShowAlertPanel());
    }
   
    public GameObject alertPanel; 
    
    private IEnumerator ShowAlertPanel()
    {
        alertPanel.SetActive(true); 
        yield return new WaitForSeconds(2f); 
        alertPanel.SetActive(false); 
    }
}
