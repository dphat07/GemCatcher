using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        ScoreManager.score = 0;
        ScoreManager.isEndGame = false;
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Restart Game");
    }

    public void mainMenuGame()
    {
        ScoreManager.score = 0;
        ScoreManager.isEndGame = false;
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("MainMenuScene Game");
    }
}
