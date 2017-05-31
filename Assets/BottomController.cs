using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomController : MonoBehaviour {

    public GameObject gameOver;
    bool goTitle = false;
	
	void Update () {
        if (goTitle)
        {
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
        goTitle = true;
    }
}
