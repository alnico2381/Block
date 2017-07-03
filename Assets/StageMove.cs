using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour {

    float speed = 3.0f;
    public static bool boss;
    public bool bosstimeone;
    public bool bosstimetwo;

	// Use this for initialization
	void Start () {
        boss = false;
        bosstimeone = true;
        bosstimetwo = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (!boss)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, 0, 0);
        }

        if (gameObject.transform.position.x <= -200)
        {
            if (bosstimeone)
            {
                boss = true;
                bosstimeone = false;
                Debug.Log("マカセテ");
            }
        }

        if (gameObject.transform.position.x <= -350)
        {
            if (bosstimetwo)
            {
                boss = true;
                bosstimetwo = false;
                Debug.Log("マカセナイデ");
            }
        }
    }
}
