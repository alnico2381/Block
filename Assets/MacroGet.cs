using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroGet : MonoBehaviour {

    GameObject nearestEnemy = null;
    GameObject[] enemys;
    float minDis = 20f;

    public GameObject item;
    GameObject itemmama;

    Transform target;
    float macrosp = 0.3f;
    int mode = 1;

    // Use this for initialization
    void Start () {

        //マクロファージくんが生成されてから数秒は待ちたい
        StartCoroutine(WaitTime(2.0f));

        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        
        // LeftWall/GameObject/Macroを登録
        itemmama = GameObject.Find("Stage/Item");

        GameObject.Find("LeftCol").GetComponent<BottomController>();

    }
	
	// Update is called once per frame
	void Update () {

        if (BottomController.goTitle == false)
        {

            if (mode == 1)
            {
                EnemySearch();
            }

            if (nearestEnemy != null)
            {
                GoEnemy();
            }
        }
    }  

    public void EnemySearch()
    {
        foreach (GameObject enemy in enemys)
        {

            if (enemy != null && !enemy.GetComponent<Enemy>().targetedIs)
            {

                float dis = Vector3.Distance(transform.position, enemy.transform.position);

                if (dis < minDis)
                {
                    minDis = dis;
                    nearestEnemy = enemy;
                }
            }
        }
    }

    public void GoEnemy()
    {
        mode = 2;
        nearestEnemy.GetComponent<Enemy>().targetedIs = true;

        target = nearestEnemy.transform;

        //Enemyに近づくアクション
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation
            (target.position - transform.position), 0.3f);

        transform.position += transform.forward * macrosp;
    }

    IEnumerator WaitTime(float time)
    {
        enabled = false;
        yield return new WaitForSeconds(time);
        enabled = true;
        Debug.Log(time + "秒待機明けました");

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            //デストロイしてアイテム(ランダム)発生させるアクション

            Vector3 itempos = new Vector3
                (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            // instance作成
            item = (GameObject)Instantiate(item, itempos, Quaternion.Euler(90, 40, 0));
            // enemyの親要素を設定（LeftWall/GameObject）
            item.transform.parent = itemmama.transform;

            Destroy(this.gameObject);
        }
    }
}
