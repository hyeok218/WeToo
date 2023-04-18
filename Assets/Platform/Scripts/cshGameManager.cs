using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class cshGameManager : MonoBehaviourPun // 점수와 게임 오버 여부 및 게임 UI를 관리하는 게임 매니저 스크립트
{
    public static cshGameManager instance // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<cshGameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static cshGameManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject[] Players;
    public Transform PlayersPos;


    public int userId;

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        userId = GameObject.FindWithTag("UserId").GetComponent<cshSelectUser>().userId;
        Vector3 randomSpawnPos = PlayersPos.position;
        PhotonNetwork.Instantiate(Players[userId].name, randomSpawnPos, Quaternion.identity);
    }
}
