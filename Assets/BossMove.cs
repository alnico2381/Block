using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {

    public static bool bossmove;

	// Use this for initialization
	void Start () {
        bossmove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (bossmove)
        {
            gameObject.transform.Rotate(2, 4, 2);
        }
	}
}
