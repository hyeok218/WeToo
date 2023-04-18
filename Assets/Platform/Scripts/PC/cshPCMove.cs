using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPCMove : MonoBehaviour
{
    public float speed = 5;
    public float gravity = -9.81f;
    public float jumpPower = 2;

    public float FPRotSpeed = 200.0f;
    public float TPRotSpeed = 300.0f;

    public GameObject CameraCenter;
    public Animator Animator;
    public Transform body;
    CharacterController character;
    float yVelocity;
    bool CamState = true; //true 1��Ī, false 3��Ī
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //--- �̵� ----
        // 1. ������� �Է¿� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //ĳ���� �̵�����
        myCharacterMove(h, v);

        //1��Ī 3��Ī ī�޶� ���� ����
        SetCameraView();
        
        //For walk animation
        Animator.SetFloat("speed", character.velocity.magnitude);
        
    }

    void SetCameraView()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CamState) // 1��Ī --> 3��Ī
            {
                CamState = false;
                CameraCenter.GetComponent<cshFPCamera>().rotSpeed = TPRotSpeed;
                CameraCenter.transform.GetChild(0).gameObject.SetActive(false);
                CameraCenter.transform.GetChild(1).gameObject.SetActive(true);
            }
            else // 3��Ī --> 1��Ī
            {
                CamState = true;
                CameraCenter.GetComponent<cshFPCamera>().rotSpeed = FPRotSpeed;
                CameraCenter.transform.GetChild(0).gameObject.SetActive(true);
                CameraCenter.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
    void myCharacterMove(float h, float v)
    {
        //--- ���� ----
        //[����]1. y�ӵ��� �߷��� ��� ���Ѵ�.
        yVelocity += gravity * Time.deltaTime;
        //[����]2. ���� ����ڰ� ������ư�� ������ y�ӵ��� �ٴ� ���� �����Ѵ�.
        if (Input.GetButtonDown("Jump") && character.isGrounded)
        {
            yVelocity = jumpPower;
        }

        // 2. �յ� �¿�� ������ �����.
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = GetComponentInChildren<Camera>().gameObject.transform.TransformDirection(dir);
        //���ý����̽����� ���彺���̽��� ��ȯ ���ش�. (Ʈ������ �������� ����� �ٲ۴�.)

        Vector3 project = Vector3.Project(dir, Vector3.up);
        dir = dir - project;

        //�밢�� �̵����� �ϸ鼭 ��Ʈ2�� ���̰� �þ�⿡ 1�� ������ش�. (����ȭ:Normalize)
        dir.Normalize();
        dir.y = yVelocity;
        character.Move(dir * speed * Time.deltaTime);
        //Move ���������� �浹 üũ�� ���ش�. ���� �浹�Ѵٸ� �����.


        //ĳ���� ���� �̵��������� �ٶ󺸵��� ����
        Vector3 look = new Vector3(dir.x, 0.0f, dir.z).normalized;
        body.transform.LookAt(body.transform.position + look);
    }
}
