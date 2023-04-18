using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cshVRUser : MonoBehaviourPun
{
    public Animator Animator;
    CharacterController character;
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
            return;
        }
        character = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
            //For walk animation
            Animator.SetFloat("speed", character.velocity.magnitude);
    }
}
