using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomController : MonoBehaviour {

    public GameObject gameOver;
    public static bool goTitle;
    public AudioClip sound01;
    private AudioSource audioSource;

    void Start()
    {
        goTitle = false;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update () {

        if (goTitle){

            //Debug.Log("ぬるぽ");

            if (Input.GetMouseButtonDown(0)){

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
            GameObject maincam = GameObject.Find("Main Camera");
            maincam.GetComponent<AudioSource>().enabled = false;
            audioSource.clip = sound01;
            audioSource.Play();

            //GameOver表示
            gameOver.SendMessage("Lose");

            //マウスの上下移動停止
            GameObject racket = GameObject.Find("Racket");
            racket.GetComponent<MouseMove>().enabled = false;

            //ステージの遷移停止
            GameObject stage = GameObject.Find("Stage");
            stage.GetComponent<StageMove>().enabled = false;

            //ボール停止(ボール破壊の場合はエラーになる？)
            Rigidbody ball = GameObject.Find("Ball").GetComponent<Rigidbody>();
            ball.constraints = RigidbodyConstraints.FreezePositionX |
                               RigidbodyConstraints.FreezePositionZ;

            //Enemy.csでエネミー停止管理
            //MacroGet.csでマクロ停止管理

            goTitle = true;

            Debug.Log("ガッ");
        }

        if (col.gameObject.tag == "Ball")
        {

            //ボール破壊、エネミー到達
            Destroy(col.gameObject);

            //BGMストップ、サウンド再生
            GameObject maincam = GameObject.Find("Main Camera");
            maincam.GetComponent<AudioSource>().enabled = false;
            audioSource.clip = sound01;
            audioSource.Play();

            //GameOver表示
            gameOver.SendMessage("Lose");

            //マウスの上下移動停止
            GameObject racket = GameObject.Find("Racket");
            racket.GetComponent<MouseMove>().enabled = false;

            //ステージの遷移停止
            GameObject stage = GameObject.Find("Stage");
            stage.GetComponent<StageMove>().enabled = false;

            //Enemy.csでエネミー停止管理
            //MacroGet.csでマクロ停止管理

            goTitle = true;

            Debug.Log("ガッ");
        }
    }
}
