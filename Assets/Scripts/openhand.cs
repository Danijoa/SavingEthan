using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openhand : MonoBehaviour
{
    private head gesture;
    private GameObject hand;
    private GameObject hand2;
    private GameObject arm;
    private GameObject arm2;
    private GameObject nice;
    private GameObject call;
    private bool isOpen = true;
    private Vector3 startRotation;
    private Vector3 startPosition;
    private Vector3 startnPosition;
    public int num = 0;
    private int check = 0;

    private GameObject light;
    private Vector3 lightposition;
    private Vector3 lightang;

    private GameObject camera;
    private Vector3 cameraang;
    private Vector3 camerapo;

    public Text TimeCount;
    public float TimeCost;
    public int min = 0;
    private bool lay = false;



    public bool chooseperson = false;
    public float timeToSel = 4.0f;

    public float countDown;
    public float showingtime;

    public GameObject redgem;
    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;

    public GameObject text;

    public GameObject WakeUpHand;
    public GameObject RescueHand;
   

    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        gesture = GetComponent<head>();
        hand = GameObject.Find("hand");
        hand2 = GameObject.Find("hand2");
        arm = GameObject.Find("arm");
        arm2 = GameObject.Find("arm2");
        nice = GameObject.Find("ok");
        call = GameObject.Find("call");
        light = GameObject.Find("Directional Light");
        startRotation = hand.transform.eulerAngles;
        startPosition = arm.transform.position;
        startnPosition = nice.transform.position;

        camera = GameObject.Find("camera");
        cameraang = camera.transform.eulerAngles;
        camerapo = camera.transform.position;

        CloseHands();
        call.active = false;
        TimeCount = GetComponent<Text>();

        redgem = GameObject.Find("RedGem");
        gem1 = GameObject.Find("Gem1");
        gem2 = GameObject.Find("Gem2");
        gem3 = GameObject.Find("Gem3");

        text = GameObject.Find("calling");

        makeallinvis();
        countDown = timeToSel;
        text.SetActive(false);
        showingtime = 3.0f;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chooseperson == false)
        {
            if (gesture.isFacingDown)
            {
                OpenHands();
            }
            else
            {
                CloseHands();
            }

            if (num > 6)
            {
                CloseHands();
                nice.transform.position = startnPosition;
                isOpen = false;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    hand.active = false;
                    hand2.active = false;
                    arm.active = false;
                    arm2.active = false;
                    nice.active = false;
                    camera.transform.eulerAngles = cameraang;
                    camera.transform.position = new Vector3(0f, 0.5f, -1.3f);
                    camera.transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    lay = true;
                }

                if(lay)TimeCost += Time.deltaTime;

                if (TimeCost >= 2)
                {
                    camera.transform.eulerAngles = cameraang;
                    camera.transform.position = camerapo;
                    call.active = true;
                    chooseperson = true;
                }
            }
        }
        else {//select the person //yeji
            Transform camera = Camera.main.transform;
            Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            RaycastHit hit;
            if (countDown < 0.0f && showingtime > 0.0f)
            {
                text.SetActive(true);
                showingtime -= Time.deltaTime;
                nice.active = true;
                call.active = false;
            }
            else {//success the call
                text.SetActive(false);
                audio.Play();

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    nice.active = false;

                    WakeUpHand.active = false;
                    RescueHand.active = true;

                    camera.transform.position = new Vector3(0.0f, 0.8f, -1.15f);
                    camera.transform.rotation = Quaternion.Euler(90.0f, -90.0f, 0f);
                }
                
            }

            if (Physics.Raycast(ray, out hit))
            {
                //hitObject = hit.collider.gameObject;//for checking
                if (hit.transform.gameObject.tag == "Red")
                {
                    if (countDown > 0.0f)
                    {
                        countDown -= Time.deltaTime;
                        makeallinvis();
                        redgem.GetComponent<MeshRenderer>().enabled = true;
                        
                    }
                }
                else if (hit.transform.gameObject.tag == "1") { makeallinvis(); gem1.GetComponent<MeshRenderer>().enabled = true; }
                else if (hit.transform.gameObject.tag == "2") { makeallinvis(); gem2.GetComponent<MeshRenderer>().enabled = true; }
                else if (hit.transform.gameObject.tag == "3") { makeallinvis(); gem3.GetComponent<MeshRenderer>().enabled = true; }
                else
                {  audio.Stop();
                    makeallinvis();
                    countDown = timeToSel;
                }
            }

        }
    }
    private void makeallinvis()
    {
        redgem.GetComponent<MeshRenderer>().enabled = false;
        gem1.GetComponent<MeshRenderer>().enabled = false;
        gem2.GetComponent<MeshRenderer>().enabled = false;
        gem3.GetComponent<MeshRenderer>().enabled = false;

    }
    private void CloseHands()
    {
        if (isOpen)
        {
            hand.transform.eulerAngles = new Vector3(180.0f, startRotation.y, startRotation.z);
            hand2.transform.eulerAngles = new Vector3(180.0f, startRotation.y, startRotation.z);
            arm.transform.position = new Vector3(4, 4, 4);
            arm2.transform.eulerAngles = new Vector3(180.0f, startRotation.y, startRotation.z);
            nice.transform.position = new Vector3(4, 4, 4);

            isOpen = true;
        }
        check = 0;

    }

    private void OpenHands()
    {
        if (isOpen)
        {
            hand.transform.eulerAngles = startRotation;
            hand2.transform.eulerAngles = startRotation;
            arm.transform.position = startPosition;
            arm2.transform.eulerAngles = startRotation;
            isOpen = true;
        }
        if (check == 0)
        {
            num++;
        }
        check++;



    }
}
