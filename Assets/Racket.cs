using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

    /*private float accel = 1000.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody>().AddForce(
            transform.right * Input.GetAxisRaw("Horizontal") * accel,
            ForceMode.Impulse);
		
	}
}*/

private GameObject Player;
private GameObject mainCamera;

// Use this for initialization
void Start(){

    //Player = GameObject.Find("Racket");
    mainCamera = GameObject.Find("Main Camera");

}


    // Update is called once per frame
    void Update()
{

    this.transform.position = new Vector3(mainCamera.transform.position.x, 0, 0);

    }
}


