using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    int bosstwolife = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(3, 5, 4));

        if (bosstwolife <= 0)
        {
            GameObject ball = GameObject.Find("Ball");
            ball.GetComponent<Ball>().ClearGame();

            Destroy(this.gameObject);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            bosstwolife -= 1;
        }
    }
}
