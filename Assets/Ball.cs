using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public GameObject gameClear;
    public float speed = 10.0f;
    public int blockCt = 10;
    Rigidbody rb;
    Vector3 v;
    public float maxSpeed = 20;

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    private AudioSource sound04;
    private AudioSource sound05;
    AudioSource[] audioSource;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        rb.AddForce((transform.forward * 0.5f + transform.right * 2.0f) * speed,
            ForceMode.VelocityChange);

        audioSource = GetComponents<AudioSource>();
        sound01 = audioSource[0];
        sound02 = audioSource[1];
        sound03 = audioSource[2];
        sound04 = audioSource[3];
        sound05 = audioSource[4];
    }

    // Update is called once per frame
    void Update () {
        
        //正規化
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;

        /*if (blockCt == 0)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameClear.SendMessage("Win");

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("title");
            }
        }*/
		
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Block")
        {
            sound01.PlayOneShot(sound01.clip);

            //blockCt -= 1;
        }

        if (col.gameObject.tag == "Enemy")
        {
            sound02.PlayOneShot(sound02.clip);
        }

        if (col.gameObject.tag == "Racket")
        {
            sound03.PlayOneShot(sound03.clip);
        }

        if (col.gameObject.tag == "Item")
        {
            sound04.PlayOneShot(sound04.clip);
        }

        if (col.gameObject.tag == "WinnerGate")
        {
            GameObject maincam = GameObject.Find("Main Camera");
            maincam.GetComponent<AudioSource>().enabled = false;

            sound05.PlayOneShot(sound05.clip);

            GetComponent<Rigidbody>().velocity = Vector3.zero;

            //マウスの上下移動停止
            GameObject racket = GameObject.Find("Racket");
            racket.GetComponent<MouseMove>().enabled = false;
            //ステージの遷移停止
            GameObject stage = GameObject.Find("Stage");
            stage.GetComponent<StageMove>().enabled = false;
            //Enemy.csでエネミー停止管理
            //MacroGet.csでマクロ停止管理

            gameClear.SendMessage("Win");

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("title");
            }

        }
    }
}
