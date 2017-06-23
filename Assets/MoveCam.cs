using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour {

    //現状未使用

    private GameObject Player;
    private GameObject mainCamera;

    // Use this for initialization
    void Start () {

        Player = GameObject.Find("Racket");
        mainCamera = GameObject.Find("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {

        mainCamera.transform.position = new Vector3(Player.transform.position.x + 18 , 5, 0);

    }
}
