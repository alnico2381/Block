using System.Collections;
using UnityEngine;

public class MouseMove : MonoBehaviour
{

    private Vector3 pos;
    public static Vector3 WorldPointPos;
    public static Vector3 mousep;
    public float time = 0.05f;
    Rigidbody rm;

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    AudioSource[] audioSource;

    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        sound01 = audioSource[0];
        sound02 = audioSource[1];
        sound03 = audioSource[2];
    }

    void Update()
    {

        pos = Input.mousePosition;

        WorldPointPos = Camera.main.ScreenToWorldPoint(pos);

        if (WorldPointPos.z <= -7.0f)
        {

            WorldPointPos.z = -7.0f;

        }

        else if (WorldPointPos.z >= 7.0f)
        {

            WorldPointPos.z = 7.0f;
        }

        mousep = new Vector3(1.5f, 0, WorldPointPos.z);

        gameObject.transform.position = mousep;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            sound01.PlayOneShot(sound01.clip);
        }

        if (collision.gameObject.tag == "Block")
        {
            sound02.PlayOneShot(sound02.clip);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            sound03.PlayOneShot(sound03.clip);
        }
    }
}
