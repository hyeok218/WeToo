using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshZoomIn : MonoBehaviour
{
    public GameObject follow;
    public float m_Zoom = 3f;

    void Update()
    {
        Zoom();
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            // ī�޶���ġ�� Ÿ����ġ�� ���
            Vector3 targetDist = transform.position - follow.transform.position;

            //Ÿ�ٰ� ī�޶� �ʹ� ������ ���� �Ұ� (1.0f�̸�)
            if (targetDist.magnitude < 1.0f && scroll > 0) return;

            //Ÿ�ٰ� ī�޶� �ʹ� �ָ� �ܾƿ� �Ұ� (10.0f �̻�)
            else if (targetDist.magnitude > 10.0f && scroll < 0) return;

            //������ �Ÿ��� �����Ӱ� ����, �ܾƿ� ����
            else
                targetDist = Vector3.Normalize(targetDist);
                transform.position -= (targetDist * scroll * m_Zoom);
        }
        transform.LookAt(follow.transform);
    }
}
