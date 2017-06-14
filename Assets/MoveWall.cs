using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{

    private GameObject Player;
    private GameObject Left;
    private GameObject Right;

    // Use this for initialization
    void Start()
    {

        Player = GameObject.Find("Racket");
        Left = GameObject.Find("LeftCol");
        Right = GameObject.Find("RightCol");

    }

    // Update is called once per frame
    void Update()
    {

        Left.transform.position = new Vector3(Player.transform.position.x - 3.7f, 0, 0);
        Right.transform.position = new Vector3(Player.transform.position.x + 40f, 0, 0);

    }
}
