using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currenType;
    public Transform buttonScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
        //btn1.onClick.AddListener(MultiPlay);  
        //btn2.onClick.AddListener(SinglePlay);
        //btn3.onClick.AddListener(Setting);
        //btn4.onClick.AddListener(Exit);
    }

    public void OnBtnClick()
    {
        switch (currenType)
        {
            case BTNType.Multi:
                Debug.Log("��Ƽ�÷���");
                SceneManager.LoadScene("MultiScene");
                break;
            case BTNType.Single:
                Debug.Log("�̱��÷���");
                SceneManager.LoadScene("SingleScene");
                break;
            case BTNType.Setting:
                Debug.Log("�ɼ�");
                break;
            case BTNType.Exit:
                Debug.Log("����");
                Application.Quit();
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }








    /*public Button btn1;
    public Transform buttonScale;
    Vector3 defaultScale;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void MultiPlay()
    {
        SceneManager.LoadScene("MultiScene");
    }

    void SinglePlay()
    {
        SceneManager.LoadScene("SingleScene");
    }

    void Setting()
    {

    }

    void Exit()
    {
        Application.Quit();
    }

   

    public void OnPointExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }*/
}
