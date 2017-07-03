using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    GameObject ball;
    GameObject ballghost;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Rotate(0, 0, 3, Space.World);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("アイテムゲット！");

            //今は一応サイズ変更だけ実装。後で場合分けしてインスタンス生成の時点で効果を決める
            ball = GameObject.Find("Ball");

            if (ball.transform.localScale.x <= 3.0f) 
            {
                ball.transform.localScale *= 1.1f;
            }

            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Racket")
        {
            Debug.Log("アイテムゲット！");

            //今は一応サイズ変更だけ実装。後で場合分けしてインスタンス生成の時点で効果を決める
            ball = GameObject.Find("Ball");
            ballghost = GameObject.Find("BallGhost");

            if (!ballghost)
            {
                if (ball.transform.localScale.x <= 3.0f)
                {
                    ball.transform.localScale *= 1.1f;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
