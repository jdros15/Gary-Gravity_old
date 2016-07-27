using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    public GameObject intro,loop;
    private AudioSource introMusic,loopMusic;
	// Use this for initialization
	void Start () {
       introMusic = intro.GetComponent<AudioSource>();
       loopMusic = loop.GetComponent<AudioSource>();
        if (!loopMusic.isPlaying)
        {
            introMusic.Play();
            Invoke("PlayMusic", 12);
        }

	}
	
	// Update is called once per frame
	void Update () {
     
	}
    void PlayMusic()
    {
        loopMusic.Play();
    }
}
