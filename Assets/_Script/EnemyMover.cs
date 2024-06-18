using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 5f;
    int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.isEndGame == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * direction);
            if (transform.position.x < -10f || transform.position.x > 10f)
            {
                direction *= -1;
            }    
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

     
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.playSound("lowDown");
            HeartManagerment.health--;
            Destroy(gameObject);
        
            if (HeartManagerment.health == 0)
            {
                ScoreManager.isEndGame = true;
            }

            //StartCoroutine(GetHurt());
        }
     
       

        
    }

    //IEnumerator GetHurt()
    //{
    //    Physics2D.IgnoreLayerCollision(6, 8);
    //    GetComponent<Animator>().SetLayerWeight(1, 1);
    //    yield return new WaitForSeconds(3f);
    //    GetComponent<Animator>().SetLayerWeight(1,0);
    //    Physics2D.IgnoreLayerCollision(6, 8, false);

    //}
}
