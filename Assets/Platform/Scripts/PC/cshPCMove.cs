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
    bool CamState = true; //true 1인칭, false 3인칭
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //--- 이동 ----
        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //캐릭터 이동제어
        myCharacterMove(h, v);

        //1인칭 3인칭 카메라 시점 변경
        SetCameraView();
        
        //For walk animation
        Animator.SetFloat("speed", character.velocity.magnitude);
        
    }

    void SetCameraView()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (CamState) // 1인칭 --> 3인칭
            {
                CamState = false;
                CameraCenter.GetComponent<cshFPCamera>().rotSpeed = TPRotSpeed;
                CameraCenter.transform.GetChild(0).gameObject.SetActive(false);
                CameraCenter.transform.GetChild(1).gameObject.SetActive(true);
            }
            else // 3인칭 --> 1인칭
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
        //--- 점프 ----
        //[점프]1. y속도에 중력을 계속 더한다.
        yVelocity += gravity * Time.deltaTime;
        //[점프]2. 만약 사용자가 점프버튼을 누르면 y속도에 뛰는 힘을 대입한다.
        if (Input.GetButtonDown("Jump") && character.isGrounded)
        {
            yVelocity = jumpPower;
        }

        // 2. 앞뒤 좌우로 방향을 만든다.
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = GetComponentInChildren<Camera>().gameObject.transform.TransformDirection(dir);
        //로컬스페이스에서 월드스페이스로 변환 해준다. (트렌스폼 기준으로 결과를 바꾼다.)

        Vector3 project = Vector3.Project(dir, Vector3.up);
        dir = dir - project;

        //대각선 이동으로 하면서 루트2로 길이가 늘어나기에 1로 만들어준다. (정규화:Normalize)
        dir.Normalize();
        dir.y = yVelocity;
        character.Move(dir * speed * Time.deltaTime);
        //Move 움직이전에 충돌 체크를 해준다. 만약 충돌한다면 멈춘다.


        //캐릭터 모델을 이동방향으로 바라보도록 설정
        Vector3 look = new Vector3(dir.x, 0.0f, dir.z).normalized;
        body.transform.LookAt(body.transform.position + look);
    }
}
