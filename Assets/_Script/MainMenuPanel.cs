using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
   public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void optionGame()
    {
        SceneManager.LoadScene("OptionScene");

    }
}
