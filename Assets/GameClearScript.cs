using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameClearScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Text>().enabled = false;
	}

    public void Win()
    {
        gameObject.GetComponent<Text>().enabled = true;
    }
	
}
