using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Breath : MonoBehaviour
{
    public GameObject black1;
    public GameObject black2;
    public GameObject pal1;
    public GameObject pal3;
    public GameObject son2;
    public GameObject text;

    float speed = 1.0f;
    float myTime;

    int flag = 0;

    Vector3 camPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            flag++;
            pal1.SetActive(false);
            pal3.SetActive(true);
            son2.SetActive(true);
            StartCoroutine(moveCam());
        }


        if(text.active == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("End");
            }
        }
    }

    IEnumerator moveCam()
    {
        for(float myTime = 0.0f; myTime < 2.0f; myTime += (Time.deltaTime%2.0f))
        {
            transform.Translate(Vector3.back * speed * Time.smoothDeltaTime * 0.13f, Space.World);
            transform.Translate(Vector3.down * speed * Time.smoothDeltaTime * 0.1f, Space.World);
            yield return new WaitForSeconds(0.0f);
        }

        for (float myTime = 2.0f; myTime < 4.0f; myTime += (Time.deltaTime % 2.0f))
        {
            black1.SetActive(true);
            black2.SetActive(true);
            Debug.Log("black");
            yield return new WaitForSeconds(0.0f);
        }
        black1.SetActive(false);
        black2.SetActive(false);

        for (float myTime = 4.0f; myTime < 6.0f; myTime += (Time.deltaTime % 2.0f))
        {
            transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime * 0.13f, Space.World);
            transform.Translate(Vector3.up * speed * Time.smoothDeltaTime * 0.1f, Space.World);
            yield return new WaitForSeconds(0.0f);
        }
        pal1.SetActive(true);
        pal3.SetActive(false);
        son2.SetActive(false);

        if (flag == 2)
        {
            text.SetActive(true);
        }
    }

}
