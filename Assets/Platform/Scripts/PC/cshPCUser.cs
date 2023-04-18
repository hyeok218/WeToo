using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshPCUser : MonoBehaviourPun
{
    public GameObject CameraCenter;


    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            Camera[] cameras;
            cameras = transform.gameObject.GetComponentsInChildren<Camera>();

            foreach (Camera c in cameras)
            {
                c.enabled = false;
            }
            CameraCenter.SetActive(false);
            GetComponent<cshPCMove>().enabled = false;
            return;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
       
    } 
}