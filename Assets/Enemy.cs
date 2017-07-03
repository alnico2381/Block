using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private AudioSource sound01;
    AudioSource audioSource;
    public bool targetedIs = false;
    bool DeathIs = false;
    public GameObject leftcol;

    void Start()
    {
        //これいる？
        //leftcol.GetComponent<BottomController>();

        audioSource = GetComponent<AudioSource>();
        sound01 = audioSource;
    }

    void Update()
    {
        if (DeathIs)
        {
            transform.Rotate(new Vector3(0, 20, 0));

            Invoke("Death", 1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Macro")
        {
            sound01.PlayOneShot(sound01.clip);
            GetComponent<EneMove>().enabled = false;
            DeathIs = true;
        }

        //現状破壊されるように

        if (collision.gameObject.tag == "Racket")
        {
            Destroy(this.gameObject);
        }
    }

    void Death()
    {
        Debug.Log("エネミー食われた");
        Destroy(this.gameObject);
    }
}
