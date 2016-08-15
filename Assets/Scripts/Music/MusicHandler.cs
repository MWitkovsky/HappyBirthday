using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

    public AudioClip intro, mainSong;

    private AudioSource src2;

    void Start()
    {
        src2 = gameObject.AddComponent<AudioSource>();

        src2.loop = true;
        src2.clip = mainSong;
        src2.PlayDelayed(intro.length);
    }
}
