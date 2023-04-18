using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshSelectUser : MonoBehaviour
{
    public int userId = 0; // 0:PC, 1:VR, 2:Avatar1, 3:Avatar2

    public Text btnUsertxt;
    string[] UserList = { "PC", "VR", "Mobile","Avatar1", "Avatar2" };
    bool AvatarSelec = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //btnUserList[userId-1].interactable = false;
        //btnUserList[userId-1].colors = setColor(btnUserList[userId - 1], Color.cyan);
        btnUsertxt.text = UserList[userId];
    }
    public void leftArrow()
    {
        userId--;
        if (userId < 0)
            userId += UserList.Length;
        userId = userId % UserList.Length;
        btnUsertxt.text = UserList[userId];
    }
    public void rightArrow()
    {
        userId++;
        userId = userId % UserList.Length;
        btnUsertxt.text = UserList[userId];
    }
}
