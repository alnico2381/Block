using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text = "Score: 0\r\n残機: 3";
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "Score:" + Block.score.ToString() + "\r\n残機:" + BottomController.balllife.ToString();
	}
}
