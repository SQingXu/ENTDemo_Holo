using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manipulation : MonoBehaviour {
    float step = 0.05f;
    Vector3 pos = new Vector3(0,0,0.5f);
    bool Calibrate = true;

    void Update()
    {
        if (Calibrate)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            Quaternion cameraRot = Camera.main.transform.rotation;
            this.transform.position = cameraPos + cameraRot * pos;
        }
    }
    void StopCalibration()
    {
        Calibrate = false;
    }

    void StartCalibration()
    {
        Calibrate = true;
    }
    void Further()
    {
        pos = new Vector3(pos.x, pos.y, pos.z + 0.1f);
    }

    void Nearer()
    {
        pos = new Vector3(pos.x, pos.y, pos.z - 0.1f);
    }

    
	
	
}
