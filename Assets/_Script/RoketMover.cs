using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketMover : MonoBehaviour
{
    public float fielfdoImpact;
    public float force;
    public LayerMask layertoHit;
    
    public float speed = 0f;

    public GameObject ExplosionEffect;


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
            SoundManager.playSound("lowDown");

            HeartManagerment.health--;

     
            GameObject EplosionEffectIns = Instantiate(ExplosionEffect,transform.position,Quaternion.identity);
            Destroy(EplosionEffectIns,10);

            //StartCoroutine(GetHurt(other.gameObject));


            Destroy(gameObject);
            if (HeartManagerment.health == 0)
            {
                ScoreManager.isEndGame = true;
            }
        }
        else if (other.gameObject.CompareTag("Ground"))
        {

          
            Destroy(gameObject);
            

        }

    }

    //IEnumerator GetHurt(GameObject player)
    //{
    //    Animator animator = player.GetComponent<Animator>();
    //    Physics2D.IgnoreLayerCollision(6, 8);
      
    //    animator.SetLayerWeight(animator.GetLayerIndex("GetHurt"), 1f);
        
    //    yield return new WaitForSeconds(3f);

    //    animator.SetLayerWeight(animator.GetLayerIndex("GetHurt"), 0);
    //    Physics2D.IgnoreLayerCollision(6, 8, false);

    //}


}
