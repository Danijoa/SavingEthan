using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public GameObject charObj;
    public GameObject ragdollObj;
    public Camera CharacterCamera;
    public Camera RagdollCamera;

    public Rigidbody spine;
    public Rigidbody head;
    public Rigidbody leg;

    public GameObject button;

    public void ShowOverheadView()
    {
        CharacterCamera.enabled = false;
        RagdollCamera.enabled = true;
    }

    public void ChangeRagdoll()
    {
        CopyAnimCharacterTransformToRagdoll(charObj.transform, ragdollObj.transform);

        charObj.gameObject.SetActive(false);
        ragdollObj.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Input.GetKeyDown(KeyCode.Space)
        {
            ChangeRagdoll();
            //ShowOverheadView();
            spine.AddForce(new Vector3(0f, 0f, -5000f));
            head.AddForce(new Vector3(0f, -2500f, 0f));
            leg.AddForce(new Vector3(0f, 0f, 2500f));

            button.active = true;
        }
    }

    private void CopyAnimCharacterTransformToRagdoll(Transform origin, Transform rag)
    {
        for (int i = 0; i < origin.transform.childCount; i++)
        {
            if (origin.transform.childCount != 0)
            {
                CopyAnimCharacterTransformToRagdoll(origin.transform.GetChild(i), rag.transform.GetChild(i));
            }
            rag.transform.GetChild(i).localPosition = origin.transform.GetChild(i).localPosition;
            rag.transform.GetChild(i).localRotation = origin.transform.GetChild(i).localRotation;
        }
    }
}
