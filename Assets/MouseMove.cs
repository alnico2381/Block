using System.Collections;
using UnityEngine;

public class MouseMove : MonoBehaviour {

    private Vector3 pos;
    private Vector3 WorldPointPos;
    //public float speed = 5.0f;
    public float time = 0.05f;
    Rigidbody rm;

    Vector3 tmp2;

    void Start()
    {
        //rm = GetComponent<Rigidbody>();
        //rm.AddForce(transform.right * speed, ForceMode.VelocityChange);

    }


    void Update() {

        pos = Input.mousePosition;

        WorldPointPos = Camera.main.ScreenToWorldPoint(pos);

        if (WorldPointPos.z <= -7.0f) {

            WorldPointPos.z = -7.0f;

        }

        else if (WorldPointPos.z >= 7.0f) {

            WorldPointPos.z = 7.0f;
        }

        //WorldPointPos.y = 0.0f;
        //WorldPointPos.x = rm.velocity.x;

        // tmp2.z = WorldPointPos.z;
        tmp2 = new Vector3(0, 0, WorldPointPos.z);

        gameObject.transform.position = tmp2;
    }
}
