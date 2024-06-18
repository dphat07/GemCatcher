using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillMover : MonoBehaviour
{
    public float speed = 5f;

    private CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GameObject.FindWithTag("Player").GetComponent<CharacterMovement>();
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
            SoundManager.playSound("phaserUp1");
            //characterMovement.speedIncreaseAmount();
            CharacterMovement.instance.speedIncreaseAmount();
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
