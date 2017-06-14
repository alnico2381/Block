using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject enemy;

    GameObject gObj;

    // Use this for initialization
    void Start () {
        // LeftWall/GameObjectを登録
        gObj = GameObject.Find("LeftWall/GameObject/Enemy");
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Ball") {

            Vector3 position = new Vector3(45, -0.5f, Random.Range(-7.0f, 7.0f));
            //Instantiate(enemy, position, Quaternion.identity);

            // instance作成
            enemy = (GameObject)Instantiate(enemy, position, Quaternion.identity);
            // enemyの親要素を設定（LeftWall/GameObject）
            enemy.transform.parent = gObj.transform;

            //enemy.transform.parent = GameObject.Find("Enemy").transform;
            Debug.Log("wwwwwwwwwwwww");

            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Racket") {

            Destroy(this.gameObject);
        }
    }

}