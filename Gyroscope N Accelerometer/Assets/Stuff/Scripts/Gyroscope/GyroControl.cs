using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    public Text gyroExists, battery;

	// Use this for initialization
	void Start () {

        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();

    }
	
	// Update is called once per frame
	void Update () {
        //Quaternion
        

        if(gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
        gyroExists.text = "" + gyroEnabled;
        battery.text = "" + SystemInfo.batteryLevel;
        
    }

    private bool EnableGyro()
    {
        //Debug.Log(SystemInfo.batteryLevel);
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }
}
