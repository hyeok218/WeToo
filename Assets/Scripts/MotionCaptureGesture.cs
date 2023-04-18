using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotionCaptureGesture : MonoBehaviour
{
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }
        // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left")
        {
            SceneManager.LoadScene(4);
        }
    }*/
    
    void OnCollisionEnter(Collision collision)
    {
        //pos = this.GameObject.transform.position;
        /*if (pos.y >= 0)
        {*/
            if (collision.collider.CompareTag("Right"))
            {
                SceneManager.LoadScene(4);
            }
       /* }*/
    }

}
