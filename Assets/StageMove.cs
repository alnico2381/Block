using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour {

    float speed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, 0, 0);
		
	}
}
