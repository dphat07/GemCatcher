using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement instance;

    public float speed = 100f;
    public float increaseSpeed = 180f;

    private Animator animator;
    private bool isMoving = true;
    
    public Rigidbody2D player;

    
    public float jumpSpeed = 5f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool doubleJump;

    bool speedIncrease = false;
   
    float currentTimeSpeed = 0f;

    

    [SerializeField]int totalCondition; 
    

    // Start is called before the first frame update
    void Start()
    {
        //bắt đầu animation khép mở chân
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        instance = this;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
       

        float moverHorizontal = Input.GetAxis("Horizontal");
        isMoving = moverHorizontal != 0;

       

        CheckEndGame();
        animator.SetBool("isMoving", isMoving);

        if (currentTimeSpeed >= 0f)
        {
            currentTimeSpeed -= Time.deltaTime;
        }
        else
        {
            speedIncrease = false;
            totalCondition = 0;
        }    
            

        
        float temp = speedIncrease ? increaseSpeed * totalCondition: speed;

        if (isMoving) 
        {
            //transform.position += new Vector3(moverHorizontal * temp * Time.deltaTime, 0f, 0f);
            player.velocity = new Vector2(moverHorizontal * temp * Time.fixedDeltaTime, player.velocity.y);

            if (moverHorizontal < 0)
            {
                transform.localScale = new Vector3(6, 6, 0);
            }
            else if (moverHorizontal > 0)
            {

                transform.localScale = new Vector3(-6, 6, 0);
            }
        }
     
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //Debug.Log("Hello");
            //if (isTouchingGround && doubleJump == false)
            //{
            //    Debug.Log("Jump");
            //    player.velocity = new Vector2(player.velocity.x, jumpSpeed * Time.fixedDeltaTime);
            //    doubleJump = true;
            //    return;
            //}
      
            //else if (doubleJump == true && isTouchingGround == false)
            //{
            //    Debug.Log("Double Jump ");
            //    player.velocity = new Vector2(player.velocity.x, jumpSpeed * Time.fixedDeltaTime * 4f);
            //    doubleJump = false;
            //    return;
            //}
        //}

      
    }

    private void Update()
    {
        if (isTouchingGround)
        {
            doubleJump = true;

        }
        if (Input.GetKey(KeyCode.Space) && isTouchingGround)
        {
            player.velocity = Vector2.up * jumpSpeed;
            Debug.Log("Jump");

        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            Debug.Log("Double Jump ");
            player.velocity = Vector2.up * jumpSpeed * 1.5f;
            doubleJump = false;

        }
    }

    void CheckEndGame()
    {
        if (ScoreManager.isEndGame == true)
        {
            //Destroy(gameObject);
            isMoving = false;
            isTouchingGround = false;
           
        }
    }

    public void speedIncreaseAmount()
    {
        totalCondition = Mathf.Min(totalCondition+1,2);
        speedIncrease = true;
        currentTimeSpeed += 5; 
        
    }

   
     
}
