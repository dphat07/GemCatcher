using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    public float speed = 8f;
    
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

    void OnTriggerEnter2D(Collider2D other) //other chính là thông tin của bất kỳ collider nào va chạm với collider này
    {


      
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.playSound("lowDown");
            HeartManagerment.health--;
           
            Destroy(gameObject);
            if (HeartManagerment.health == 0 )
            {
                ScoreManager.isEndGame = true;
            }

            //StartCoroutine(GetHurt());
        }
      
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }


    }

    //IEnumerator GetHurt()
    //{
    //    Physics2D.IgnoreLayerCollision(6, 8);
    //    GetComponent<Animator>().SetLayerWeight(1, 1);
    //    yield return new WaitForSeconds(3f);
    //    GetComponent<Animator>().SetLayerWeight(1, 0);
    //    Physics2D.IgnoreLayerCollision(6, 8, false);

    //}
}
