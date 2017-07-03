using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomController : MonoBehaviour {

    public static bool goTitle;
    private bool onPlay;
    public GameObject gameOver;
    public GameObject ghost;
    Vector3 ghostpos;

    public GameObject maincam;
    public GameObject racket;
    public GameObject stage;
    GameObject enemy;

    GameObject ball;

    public AudioClip sound01;
    private AudioSource audioSource;

    public static int balllife;

    void Start()
    {
        ghost.SetActive(false);
        goTitle = false;
        onPlay = true;
        balllife = 10;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update () {

        if (balllife <= 0 && onPlay)
        {
            //BGMストップ、サウンド再生
            maincam.GetComponent<AudioSource>().enabled = false;
            audioSource.clip = sound01;
            audioSource.Play();

            //GameOver表示
            gameOver.SendMessage("Lose");

            //マウスの上下移動停止
            racket.GetComponent<MouseMove>().enabled = false;

            //ステージの遷移停止
            stage.GetComponent<StageMove>().enabled = false;

            //アイテムの回転停止

            //エネミーの移動停止
            enemy = GameObject.Find("Stage/Enemy");
            Transform children = enemy.transform.GetComponentInChildren<Transform>();

            foreach (Transform child in children) {
                child.gameObject.GetComponent<EneMove>().enabled = false;
            }

            //Enemy.csでエネミー停止管理
            //MacroGet.csでマクロ停止管理

            goTitle = true;

            Debug.Log("ガッ");
        }

        if (goTitle)
        {

            if (onPlay)
            {
                onPlay = false;
            }

            if (Input.GetMouseButtonDown(0))
            {

                SceneManager.LoadScene("title");

            }
        }
    }

    void OnCollisionEnter(Collision col){

        if (col.gameObject.tag == "Enemy")
        {

            //ボール破壊、エネミー到達
            Destroy(col.gameObject);
            
            //BGMストップ、サウンド再生
            //audioSource.clip = sound01;
            //audioSource.Play();

            /*
            //マウスの上下移動停止
            racket.GetComponent<MouseMove>().enabled = false;

            //ステージの遷移停止
            stage.GetComponent<StageMove>().enabled = false;

            //ボール停止及びボールクローンがいたら止める
            ball = GameObject.Find("Ball");
            Rigidbody ballrb;

            if (ball)
            {
                ballrb = ball.GetComponent<Rigidbody>();
                ballrb.constraints = RigidbodyConstraints.FreezePositionX |
                                   RigidbodyConstraints.FreezePositionZ;
            }*/

            //Enemy.csでエネミー停止管理
            //MacroGet.csでマクロ停止管理

            //GameOver表示
            //gameOver.SendMessage("Lose");
            //goTitle = true;

            --balllife;
            Debug.Log(balllife);

            Debug.Log("ガッ");
            
        }

        if (col.gameObject.tag == "Ball")
        {

            //ボール破壊、ライフカウント
            Destroy(col.gameObject);
            --balllife;
            Debug.Log(balllife);

            //ghostをオンにする(SetActiveで作る)
            if (balllife != 0)
            {
                ghost.SetActive(true);
            }

            Debug.Log("ゴースト出しました");
        }
    }
}
