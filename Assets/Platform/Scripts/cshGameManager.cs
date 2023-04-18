using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class cshGameManager : MonoBehaviourPun // ������ ���� ���� ���� �� ���� UI�� �����ϴ� ���� �Ŵ��� ��ũ��Ʈ
{
    public static cshGameManager instance // �ܺο��� �̱��� ������Ʈ�� �����ö� ����� ������Ƽ
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if (m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�� �Ҵ�
                m_instance = FindObjectOfType<cshGameManager>();
            }

            // �̱��� ������Ʈ�� ��ȯ
            return m_instance;
        }
    }

    private static cshGameManager m_instance; // �̱����� �Ҵ�� static ����

    public GameObject[] Players;
    public Transform PlayersPos;


    public int userId;

    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if (instance != this)
        {
            // �ڽ��� �ı�
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
