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
            // 카메라위치와 타겟위치를 계산
            Vector3 targetDist = transform.position - follow.transform.position;

            //타겟과 카메라가 너무 가까우면 줌인 불가 (1.0f미만)
            if (targetDist.magnitude < 1.0f && scroll > 0) return;

            //타겟과 카메라가 너무 멀면 줌아웃 불가 (10.0f 이상)
            else if (targetDist.magnitude > 10.0f && scroll < 0) return;

            //적당한 거리면 자유롭게 줌인, 줌아웃 가능
            else
                targetDist = Vector3.Normalize(targetDist);
                transform.position -= (targetDist * scroll * m_Zoom);
        }
        transform.LookAt(follow.transform);
    }
}
