using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip getPointSound, minusPointSound;
    static AudioSource audioSource;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       audioSource.loop = false;
    }

    void Start()
    {
        getPointSound = Resources.Load<AudioClip>("phaserUp1");
        minusPointSound = Resources.Load<AudioClip>("lowDown");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound (string clip)
    {
        switch (clip)
        {
            case "phaserUp1":
            {
                audioSource.PlayOneShot(getPointSound);
                break;
            }
            case "lowDown":
            {
                audioSource.PlayOneShot(minusPointSound);
                break;
            }


        }
    }    
}
