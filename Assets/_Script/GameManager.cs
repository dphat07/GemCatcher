using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    public int selectedOption = 0;


    public GameObject greenCharacter;
    public GameObject blueCharacter;
    public GameObject pinkCharacter;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        if (selectedOption == 0)
        {
            Instantiate(blueCharacter);
        }
        else if (selectedOption == 1) {
            Instantiate(greenCharacter);

        }
        else
        {
            Instantiate(pinkCharacter);
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

}
