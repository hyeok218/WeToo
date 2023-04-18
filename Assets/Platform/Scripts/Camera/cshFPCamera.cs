using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFPCamera : MonoBehaviour
{
    public float camSpeed = 1.0f; // ȭ���� �����̴� �ӵ� ����
    private float yaw = 0.0f; // 
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        yaw += camSpeed * Input.GetAxis("Mouse X"); // ���콺X���� ���������� ���� ����
        pitch += camSpeed * Input.GetAxis("Mouse Y"); // ���콺y���� ���������� ���� ����
        yaw %= 360.0f;
        // Mathf.Clamp(x, �ּҰ�, �ִ�) - x���� �ּ�,�ִ밪 ���̿����� ���ϰ� ����
        pitch = Mathf.Clamp(pitch, -50f, 30f); // pitch���� ����������

        transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f); // �ޱ۰��� �������� ���� �־���
    }
    
    
}
