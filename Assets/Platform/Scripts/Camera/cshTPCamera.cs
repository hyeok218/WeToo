using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshTPCamera : MonoBehaviour
{
    public Transform follow;
    public float m_Speed = 3.0f;
    float m_MaxRayDist = 1;
    float m_Zoom = 3f;
    RaycastHit m_Hit;

    float mx;
    float my;
    public void LateUpdate()
    {
        Rotate();
        Zoom();
    }

    void Rotate()
    {
        //���콺 Ŭ���ø� ȭ���� ȸ���ϵ��� ��
        if (Input.GetMouseButton(0))
        {
            mx = Input.GetAxis("Mouse X"); //����â���� ���콺�� ���� ���������� �̵��Ҷ� ���� (�� -���� : ���� +���)
            my = Input.GetAxis("Mouse Y"); //����â���� ���콺�� ���� ���������� �̵��Ҷ� ���� (�Ʒ� -���� : �� +���)       

            Quaternion q = follow.rotation;
            q.eulerAngles = new Vector3(q.eulerAngles.x - my * m_Speed, q.eulerAngles.y + mx * m_Speed, q.eulerAngles.z);

            float clampx = q.eulerAngles.x;
            if (q.eulerAngles.x >= 180.0f) clampx = q.eulerAngles.x - 360.0f;
            clampx = Mathf.Clamp(clampx, -40.0f, 60.0f);

            q.eulerAngles = new Vector3(clampx, q.eulerAngles.y, q.eulerAngles.z);
            follow.rotation = q;
        }
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Transform cam = GetComponent<Camera>().transform;   
            Vector3 targetDist = cam.transform.position - follow.transform.position;
            targetDist = Vector3.Normalize(targetDist);
            Camera.main.transform.position -= (targetDist * scroll * m_Zoom); 
        }
        Camera.main.transform.LookAt(follow.transform);
    }
 
}
