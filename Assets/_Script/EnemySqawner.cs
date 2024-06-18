using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySqawner : MonoBehaviour
{
    public GameObject enemyPrefabs;

    private float timer;

    private float spawnInterval = 10f;
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
                EnemySqawn();
                timer = 0;
            }
            else
                Destroy(gameObject);
        }
    }

    void EnemySqawn()
    {
        float positionY = -3.8f;
        Vector3 spawnPosition = new Vector3(10f, positionY, 0);
        Instantiate(enemyPrefabs, spawnPosition, Quaternion.identity);
    }
}
