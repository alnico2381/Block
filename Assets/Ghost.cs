using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public GameObject ball;
    public GameObject racket;
    Vector3 ballpos;

    // Use this for initialization
    void Start () {

    }

    void OnEnable()
    {
        racket.GetComponent<MouseMove>();
    }

    // Update is called once per frame
    void Update () {

        ballpos = new Vector3(MouseMove.mousep.x + 1.0f, 0, MouseMove.WorldPointPos.z);

        gameObject.transform.position = ballpos;

        if (Input.GetMouseButtonUp(0))
        {
            // instance作成
            GameObject ballclone = Instantiate(ball, ballpos, Quaternion.identity);
            ballclone.name = "Ball";

            gameObject.SetActive(false);
        }

    }
}
