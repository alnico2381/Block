using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject enemy;
    public GameObject macro;

    //public GameObject maincam;

    public static int score;

    //GameObject enemama;
    GameObject macromama;

    // Use this for initialization
    void Start () {

        // LeftWall/GameObject/Enemyを登録
        //enemama = GameObject.Find("Stage/Enemy");
        // LeftWall/GameObject/Macroを登録
        macromama = GameObject.Find("Stage/Macro");

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision) {


        if (collision.gameObject.tag == "Ball")
        {
            if (!StageMove.boss)
            {
                /*
                Vector3 enepos = new Vector3(45, gameObject.transform.position.y, Random.Range(-7.0f, 7.0f));

                // instance作成
                enemy = (GameObject)Instantiate(enemy, enepos, Quaternion.Euler(0, -90, -90));
                // enemyの親要素を設定（LeftWall/GameObject）
                enemy.transform.parent = enemama.transform;
                */

                Vector3 macpos = new Vector3
                    (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

                // instance作成
                macro = (GameObject)Instantiate(macro, macpos, Quaternion.Euler(0, 90, 0));
                // enemyの親要素を設定（LeftWall/GameObject）
                macro.transform.parent = macromama.transform;

                //enemy.transform.parent = GameObject.Find("Enemy").transform;

                score += 1;
            }
            Destroy(this.gameObject);
        }


        if (collision.gameObject.tag == "Racket") {
            //現状ブロックはスルー
            //Destroy(this.gameObject);

        }
    }
}