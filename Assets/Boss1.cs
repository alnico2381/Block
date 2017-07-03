using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    int bossonelife = 5;
    public GameObject maincam;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(3, 5, 4));

        if (bossonelife <= 0){

            maincam.GetComponent<AudioSource>().pitch *= 1.15f; 

            StageMove.boss = false;
            Destroy(this.gameObject);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            bossonelife -= 1;
        }
    }
}
