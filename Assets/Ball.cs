using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    public GameObject gameClear;
    public float speed = 10.0f;
    Rigidbody rb;
    Vector3 v;
    public float maxSpeed = 20;

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    private AudioSource sound04;
    private AudioSource sound05;
    private AudioSource sound06;
    private AudioSource sound07;
    AudioSource[] audioSource;

    Vector3 ballVelocity;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.AddForce((/*transform.forward * 0.5f + */transform.right * 2.0f) * speed,
            ForceMode.VelocityChange);

        audioSource = GetComponents<AudioSource>();
        sound01 = audioSource[0];
        sound02 = audioSource[1];
        sound03 = audioSource[2];
        sound04 = audioSource[3];
        sound05 = audioSource[4];
        sound06 = audioSource[5];
        sound07 = audioSource[6];

        ballVelocity = GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //正規化
        ballVelocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        GetComponent<Rigidbody>().velocity = ballVelocity;

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

            if (Mathf.Abs(ballVelocity.z) < 1.0f)
            {
                Debug.Log(GetComponent<Rigidbody>().velocity);
                ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
                ballVelocity.z += 0.1f;
                ballVelocity.z *= 3.0f;
                GetComponent<Rigidbody>().velocity = ballVelocity;
                Debug.Log("ラケットからZ方向補正" + GetComponent<Rigidbody>().velocity);
            }
        }

        if (col.gameObject.tag == "Wall")
        {
            Debug.Log(GetComponent<Rigidbody>().velocity);

            if (Mathf.Abs(ballVelocity.x) < 3.0f)
            {
                ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
                ballVelocity.x += 0.1f;
                ballVelocity.x *= 3.0f;
                GetComponent<Rigidbody>().velocity = ballVelocity;
                Debug.Log("壁からX方向補正" + GetComponent<Rigidbody>().velocity);
            }
            if (Mathf.Abs(ballVelocity.z) < 3.0f)
            {
                ballVelocity = gameObject.GetComponent<Rigidbody>().velocity;
                ballVelocity.z += 0.1f;
                ballVelocity.z *= 3.0f;
                GetComponent<Rigidbody>().velocity = ballVelocity;
                Debug.Log("壁からZ方向補正" + GetComponent<Rigidbody>().velocity);
            }
        }

        if (col.gameObject.tag == "Item")
        {
            sound04.PlayOneShot(sound04.clip);
        }

        if (col.gameObject.tag == "Boss1")
        {
            sound06.PlayOneShot(sound06.clip);
        }

        if (col.gameObject.tag == "Boss2")
        {
            sound07.PlayOneShot(sound07.clip);
        }
    }

    public void ClearGame()
    {
        GameObject maincam = GameObject.Find("Main Camera");
        maincam.GetComponent<AudioSource>().enabled = false;

        sound05.PlayOneShot(sound05.clip);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //マウスの上下移動停止
        GameObject racket = GameObject.Find("Racket");
        racket.GetComponent<MouseMove>().enabled = false;
        //ステージの遷移停止
        //GameObject stage = GameObject.Find("Stage");
        //stage.GetComponent<StageMove>().enabled = false;
        //Enemy.csでエネミー停止管理
        //MacroGet.csでマクロ停止管理

        gameClear.SendMessage("Win");

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("title");
        }
    }
}
