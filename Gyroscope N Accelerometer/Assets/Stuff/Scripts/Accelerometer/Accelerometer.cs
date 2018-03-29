using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour {

    Rigidbody rgb;

    public bool isFlat = true;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 tilt = Input.acceleration;

        if(isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }

        rgb.AddForce(tilt);
	}
}
