using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    public static bool isEndGame = false;
   
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
  
    public static int score = 0; //static sẽ được giải thích sau trong chương c#

    public static float remainingTime;
    public TextMeshProUGUI scoreText; // tạo một biến thuộc kiểu TextMeshProUGUI tên scoreText và có thể truy cập từ Unity Editor

    // khai báo một hàm dành cho lớp ScoreManager nhằm tăng số điểm của người chơi
    public static void AddScore(int amount) //(int amount) nghĩa là hàm sẽ chỉ nhận giá trị là integer, và giá trị này sẽ được gán vào biến có tên amount
    {
        score += amount; //tăng điểm theo giá trị của amount được truyền vào tại sự kiện gọi AddScore
    }

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = 30f;
        StartCoroutine(CountDownTimer());

    }

    // Update is called once per frame
    void Update()
    {
        // cập nhật điểm hiển thị trên UI
        scoreText.text = "Score: " + score + " | Time: " + remainingTime; // -> Score: 10 hoặc Score: 5 ...
        if (remainingTime == 0 && !gameOverPanel.activeInHierarchy)
        {
         
            GameOver();
          
            //Destroy(gameObject);
            


        }
        else if (isEndGame == true)
        {
           
            GameOver();
            
        }
       
       
      
    }

    private IEnumerator CountDownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
       
    }

    private void GameOver()
    {
       
        gameOverText.text = "Game Over !\nYour Score: " + score;
        gameOverPanel.SetActive(true);
        StopAllCoroutines();


    }

   
}
