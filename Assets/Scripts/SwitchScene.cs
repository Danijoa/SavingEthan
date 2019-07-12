using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    public void st()
    {
        SceneManager.LoadScene("Start");
    }

    public void Third()
    {
        SceneManager.LoadScene("3rd");
    }

    public void First()
    {
        SceneManager.LoadScene("1st");
    }

    public void ending()
    {
        SceneManager.LoadScene("End");
    }



    // Update is called once per frame
    void Update () {
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            ending();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            st();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            First();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Third();
        }

    }
}
