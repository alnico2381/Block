using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("アイテムゲット！");
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Racket")
        {
            Debug.Log("アイテムゲット！");
            Destroy(this.gameObject);
        }
    }
}
