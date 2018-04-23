using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum PlayerState // 애니매이션 열거형
{
    Idle,Front,Back,Left,Right
}


public class PlayerMove : MonoBehaviour {

    public float speed = 5f;
    public float RotationSpeed = 2f;
    Rigidbody rigidbody;

    Vector3 movePos;
    
    Animator anim;
    PlayerState State;
    private float h2;
    private float v2;
    private bool mobile = false;
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        State = PlayerState.Idle;
    }
    public void OnStickChanged(Vector2 stickPos)
    {
        h2 = stickPos.x;
        v2 = stickPos.y;
    }

    void Update () {

        /////////////////////////////////////////
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        /////////////////////////////////////////

        if(Input.GetKey(KeyCode.Q)== true)
        {
            mobile = true;
        }
        else if(Input.GetKey(KeyCode.Z) == true)
        {
            mobile = false;
        }

        ////
        if (mobile == false)
        {
            Running(h, v);
        }
        else
        {
            Running(h2, v2);
        }
        
        PlayerAnimation(anim);
       
        
    }
    void Running(float hor, float vir)
    {
        movePos.Set(hor, 0, vir);
        movePos = movePos.normalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movePos);
       
        //// 애니매이션 제어
        if (hor > 0) //왼쪽
        {
            State = PlayerState.Left;
            
        }
        if(hor < 0) // 오른쪽
        {
            State = PlayerState.Right;
        }
        if(vir > 0) // 앞
        {
            State = PlayerState.Front;
            if(hor > 0)
            {
                State = PlayerState.Left;
            }
            else if(hor < 0)
            {
                State = PlayerState.Right;
            }
        }
        if(vir < 0) //뒤
        {
            State = PlayerState.Back;
            if (hor > 0)
            {
                State = PlayerState.Left;
            }
            else if (hor < 0)
            {
                State = PlayerState.Right;
            }
        }
        if(hor == 0&& vir == 0) //제자리
        {
            State = PlayerState.Idle;
        }
        PlayerRotate();
    }
    void PlayerAnimation(Animator anim)
    {
        //상태 초기화
        State = PlayerState.Idle;

        if (State == PlayerState.Front)//앞
        {
            anim.SetBool("Running", true);
            anim.SetBool("BackRunning", false);
            anim.SetBool("RightRunning", false);
            anim.SetBool("LeftRunning", false);
            anim.SetBool("Idle", false);
        }
        if (State == PlayerState.Back)//뒤
        {
            anim.SetBool("Running", false);
            anim.SetBool("BackRunning", true);
            anim.SetBool("RightRunning", false);
            anim.SetBool("LeftRunning", false);
            anim.SetBool("Idle", false);
        }
        /////////////////////////////////////
        if (State == PlayerState.Right) //오른쪽
        {
            anim.SetBool("Running", false);
            anim.SetBool("BackRunning", false);
            anim.SetBool("RightRunning", true);
            anim.SetBool("LeftRunning", false);
            anim.SetBool("Idle", false);
        }
        if (State == PlayerState.Left) // 왼쪽
        {
            anim.SetBool("Running", false);
            anim.SetBool("BackRunning", false);
            anim.SetBool("RightRunning", false);
            anim.SetBool("LeftRunning", true);
            anim.SetBool("Idle", false);
        }

        if (State == PlayerState.Idle)
        {
            anim.SetBool("Running", false);
            anim.SetBool("BackRunning", false);
            anim.SetBool("RightRunning", false);
            anim.SetBool("LeftRunning", false);
            anim.SetBool("Idle", true);
        }
    }
    void PlayerRotate()
    {
        if(State== PlayerState.Back) // 움직이지않으면 정면을 바라보게함
        {
            return;
        }
        // LookRotation(vector) -> 앞을 보게하는 회전값 (1,0,5)라면 그에맞게 캐릭을 회전하여 앞을 보게함
        Quaternion PlayerRotation = Quaternion.LookRotation(movePos);
        // slerp함수를 이용하여 물체의 회전을 지정한 회전으로 바꿉니다.this.rotation~ playerRotation
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, PlayerRotation, RotationSpeed * Time.deltaTime);
    }

}
