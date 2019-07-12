using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Push : MonoBehaviour {

    Vector3 upPos;
    private AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        

		if(Input.GetKeyDown(KeyCode.P))
        {
            upPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(cameraPush());
        }
    }

    IEnumerator cameraPush()
    {

        for (int i = 0; i < 5; i++)
        {
            Vector3 downPos = new Vector3(transform.position.x, 0.4f, transform.position.z);
            transform.position = downPos;
            audio.Play();

            yield return new WaitForSeconds(0.6f);
                       
            //Vector3 upPos = new Vector3(transform.position.x, -0.65f, transform.position.z);
            transform.position = upPos;

            Debug.Log(i + 1);

            yield return new WaitForSeconds(0.6f);
        }
    }
}
