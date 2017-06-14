using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomController : MonoBehaviour {

    public GameObject gameOver;
    public bool goTitle = false;
	
	void Update () {
        if (goTitle)
        {
            Debug.Log("nununu");
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("title");
            }
        }
		
	}

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);

        gameOver.SendMessage("Lose");

        GameObject racket = GameObject.Find("Racket");
        racket.GetComponent<MouseMove>().enabled = false;

        GameObject leftwall = GameObject.Find("LeftWall");
        leftwall.GetComponent<StageMove>().enabled = false;

        /*Rigidbody racketrb;
        racketrb = GameObject.Find("Racket").GetComponent<Rigidbody>();
        racketrb.constraints = RigidbodyConstraints.FreezePositionX |
                               RigidbodyConstraints.FreezePositionY |
                               RigidbodyConstraints.FreezePositionZ |
                               RigidbodyConstraints.FreezeRotationX |
                               RigidbodyConstraints.FreezeRotationY |
                               RigidbodyConstraints.FreezeRotationZ;
                               */

        goTitle = true;
        Debug.Log("-------nununu");
    }
}
