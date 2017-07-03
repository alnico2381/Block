using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour {

    private AudioSource sound01;

    // Use this for initialization
    void Start () {

        sound01 = GetComponent<AudioSource>();

        Invoke("Audio", 1.0f);

    }

    void Audio()
    {
        sound01.PlayOneShot(sound01.clip);
    }
}
