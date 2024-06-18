using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRedFall : MonoBehaviour
{

    public GameObject gemRedPrefab;
  
    private float timer;

    private float spawnInterval = 4f;

    // Start is called before the first frame update
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
                SpawnGemRed(); 
                timer = 0; 

            }
            else
                Destroy(gameObject);
        }
    }

    void SpawnGemRed()
    {
     
        float randomX = Random.Range(-8f, 8f); 
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0); 
        Instantiate(gemRedPrefab, spawnPosition, Quaternion.identity);
    }

}
