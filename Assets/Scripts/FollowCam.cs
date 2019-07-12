using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform head;
    public float dist = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5.0f;

    private Transform tr;

	// Use this for initialization
	void Start () {

        tr = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, head.eulerAngles.y, smoothRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
        tr.position = head.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(head);
		
	}
}
