using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject BackGroundMusic;
    AudioSource bgmusic;

    void Awake()
    {
        BackGroundMusic = GameObject.Find("BackgroundMusic");
        bgmusic = BackGroundMusic.GetComponent<AudioSource>();
        if (!bgmusic.isPlaying)
        {
            bgmusic.Play();
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            return;
        }
    }

    public int BgMusicOff()
    {
        BackGroundMusic = GameObject.Find("BackgroundMusic");
        bgmusic = BackGroundMusic.GetComponent<AudioSource>();

        if (!bgmusic.isPlaying)
        {
            return 0; //0:ÀÌ¹Ì ÄÑÁü, 1:¼º°øÀûÀ¸·Î ¸ØÃã
        }
        else
        {
            bgmusic.Pause();
            return 1;
        }

    }

}
