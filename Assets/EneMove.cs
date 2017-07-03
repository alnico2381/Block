using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneMove : MonoBehaviour {

    private Vector3 position;
    private Vector3 screenToWorldPointPos;
	
	// Update is called once per frame
	void Update () {

        position = gameObject.transform.position;

        Vector3 worPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));

        if (position.x <= worPos.x)
        {
            position.x -= 0.05f;
            gameObject.transform.position = position;
        }
	}
}
