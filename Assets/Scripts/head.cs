using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour {
    public bool isFacingDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        isFacingDown = DetectFacingDown();
	}

    private bool DetectFacingDown()
    {
        return(CameraAngleFromGround() < 40.0f);
    }

    private float CameraAngleFromGround()
    {
        return Vector3.Angle(Vector3.down, Camera.main.transform.rotation * Vector3.forward);
    }
}
