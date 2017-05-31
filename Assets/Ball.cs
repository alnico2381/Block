using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public GameObject gameClear;
    int speed = 10;
    public int blockCt = 20;
    Rigidbody rb;
    Vector3 v;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce((transform.forward + transform.right) * speed,
            ForceMode.VelocityChange);
		
	}
	
	// Update is called once per frame
	void Update () {

        if (blockCt == 0)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameClear.SendMessage("Win");

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("title");
            }
        }
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Block")
        {
            blockCt -= 1;
            Debug.Log(blockCt);
        }
    }
}
