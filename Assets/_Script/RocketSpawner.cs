using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{

  
    public GameObject rocketPrefab;
   
    private float timer;
   
    private float spawnInterval = 3f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnInterval)
        {
            if (ScoreManager.isEndGame == false)
            {
                SpawnRocket();
                timer = 0; 

            }
            else
                Destroy(gameObject);
        }
    }

    void SpawnRocket()
    {
     
        float randomX = Random.Range(-6f, 6f); 
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0); 
        Instantiate(rocketPrefab, spawnPosition, Quaternion.identity);
    }
}
