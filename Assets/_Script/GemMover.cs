using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMover : MonoBehaviour
{

  
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (ScoreManager.isEndGame == false)
        {
          
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
        

    }

  
    void OnTriggerEnter2D(Collider2D other) 
    {

       
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.playSound("phaserUp1");

            ScoreManager.AddScore(1);

          
            Destroy(gameObject);
       
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
          
            Destroy(gameObject);
        
        }

    }
}
