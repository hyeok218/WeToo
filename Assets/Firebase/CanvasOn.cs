using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOn : MonoBehaviour
{

    public CanvasGroup loginMenu;
    public CanvasGroup connectMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    

   /* CanvasGroupOn(loginMenu);
    CanvasGroupOff(connectMenu);*/

    // Update is called once per frame
    void Update()
    {
        if (FirebaseAuthManager.Instance.cnt == 1)
        {
            Debug.Log("connect");
            CanvasGroupOn(connectMenu);
            CanvasGroupOff(loginMenu);
            FirebaseAuthManager.Instance.cnt = 3;
        }

        else if(FirebaseAuthManager.Instance.cnt == 0)
        {
            CanvasGroupOn(loginMenu);
            CanvasGroupOff(connectMenu);
            FirebaseAuthManager.Instance.cnt = 2;
        }
    }
}
