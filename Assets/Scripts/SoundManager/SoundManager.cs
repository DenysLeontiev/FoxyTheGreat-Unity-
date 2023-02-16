using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource music;

    private bool canMusicPlay = true;

    private void Awake()
    {
        if(this == null)
        {
            instance = this;
        }

        //if(instance != null )
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
    }

    private void Start()
    {
        music.Play();
    }

    private void Update()
    {
        if (!music.isPlaying && canMusicPlay)
        {
            music.UnPause();
        }

        if (music.isPlaying && !canMusicPlay)
        {
            music.Pause();
        }
    }

    public void SetSoundMode()
    {
        print("Clicked");
        if (music.isPlaying && canMusicPlay)
        {
            music.volume = 0f;
            print("Disable");
            canMusicPlay = false;
        }
        else
        {
            music.volume = 1f;
            print("Ensable");
            canMusicPlay = true;
        }
    }
}
