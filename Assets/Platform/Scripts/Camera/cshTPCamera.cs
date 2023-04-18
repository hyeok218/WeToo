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
        //마우스 클릭시만 화면이 회전하도록 함
        if (Input.GetMouseButton(0))
        {
            mx = Input.GetAxis("Mouse X"); //게임창에서 마우스를 왼쪽 오른쪽으로 이동할때 마다 (왼 -음수 : 오른 +양수)
            my = Input.GetAxis("Mouse Y"); //게임창에서 마우스를 왼쪽 오른쪽으로 이동할때 마다 (아래 -음수 : 위 +양수)       

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
