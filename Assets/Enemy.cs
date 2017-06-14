using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")
        {

            Destroy(this.gameObject);
        }


        if (collision.gameObject.tag == "Racket")
        {

            Destroy(this.gameObject);
        }
    }
}
