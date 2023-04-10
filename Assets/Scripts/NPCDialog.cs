using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject toActivate;

    [SerializeField] private Transform standingPoint;

    Transform avatar;

    // Start is called before the first frame update
    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            avatar = other.transform;

            //disable player input
            avatar.GetComponent<PlayerController>().enabled = false;

            await Task.Delay(50);

            // teleport the avatar to standing point
            avatar.position = standingPoint.position;
            avatar.rotation = standingPoint.rotation;


            //disable main cam, enable dialog cam
            mainCamera.SetActive(false);
            toActivate.SetActive(true);

            //disable cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            

            //gpt chat ui

            
        }

        

    }

    // recover
    public void Recover()
    {
        avatar.GetComponent<PlayerController>().enabled = true;

        mainCamera.SetActive(true);
        toActivate.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
