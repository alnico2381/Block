using System.Collections;
using UnityEngine;

public class MouseMove : MonoBehaviour {

    private Vector3 pos;
    private Vector3 WorldPointPos;

	// Update is called once per frame
	void Update () {

        pos = Input.mousePosition;

        WorldPointPos = Camera.main.ScreenToWorldPoint(pos);

        if(WorldPointPos.x <= -3.5f){

            WorldPointPos.x = -3.5f;

        }

        else if (WorldPointPos.x >= 3.5f){

                WorldPointPos.x = 3.5f;
            }

            WorldPointPos.y = 0.0f;
            WorldPointPos.z = -6.0f;

            gameObject.transform.position = WorldPointPos;

	}
}
