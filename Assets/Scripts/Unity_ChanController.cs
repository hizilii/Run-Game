using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_ChanController : MonoBehaviour
{
    const int MinLane=-1;
    const int MaxLane=1;
    const float LaneWidth=1.5f;

    Animator animator;
    CharacterController controller;

    Vector3 moveDirection=Vector3.zero;
    int targetLane;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    float countdown=4f;
    int count;

    const int MaxLife=3;
    const int MinOnigiri=0;
    const float StunDuration=0.5f;
    int life=MaxLife;
    int onigiri=MinOnigiri;
    float recoverTime=0.0f;

    void Start()
    {
        animator=GetComponent<Animator>();
        controller=GetComponent<CharacterController>();
    }

    public int Life(){
        return life;
    }

    public int Onigiri(){
        return onigiri;
    }

    bool IsStun(){
        return recoverTime>0.0f || life<=0;
    }

    void Update()
    {
        // デバッグ用
        if(Input.GetKey("left")) MoveToLeft();
        if(Input.GetKey("right")) MoveToRight();
        if(Input.GetKey("space")) Jump();

        if(countdown>=0){
            countdown-=Time.deltaTime;
            count=(int)countdown;
        }if(countdown<=0){
            if(IsStun()){
            // 動きを止めてスタンから復帰するタイムをカウント
            moveDirection.x=0.0f;
            moveDirection.z=0.0f;
            recoverTime-=Time.deltaTime;
            }else{
                // Z方向に常に前進
                float acceleratedZ=moveDirection.z+(accelerationZ*Time.deltaTime);
                moveDirection.z=Mathf.Clamp(acceleratedZ,0,speedZ);

                //X方向は目標のポジションまでの差分の割合で速度を計算
                float ratioX=(targetLane*LaneWidth-transform.position.x)/LaneWidth;
                moveDirection.x=ratioX*speedX;
            }

            // 重力分の力を毎フレーム追加
            moveDirection.y-=gravity*Time.deltaTime;

            // 移動
            Vector3 globalDirection=transform.TransformDirection(moveDirection);
            controller.Move(globalDirection*Time.deltaTime);

            // 移動後接地してたらY方向の速度はリセット
            if(controller.isGrounded) moveDirection.y=0;

            // 速度が0以上の時、runのフラグをtrueに
            animator.SetBool("run",moveDirection.z>0.0f);
        }
    }

    // 左のレーンに移動
    public void MoveToLeft(){
        if(IsStun()) return;
        if(controller.isGrounded && targetLane>MinLane) targetLane--;
    }

    // 右のレーンに移動
    public void MoveToRight(){
        if(IsStun()) return;
        if(controller.isGrounded && targetLane<MaxLane) targetLane++;
    }

    public void Jump(){
        if(IsStun()) return;
        if(controller.isGrounded){
            moveDirection.y=speedJump;

            animator.SetTrigger("jump");
        }
    }

    // ユニティちゃん衝突時
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(IsStun()) return;

        if(hit.gameObject.tag=="Enemy"){
            life--;
            recoverTime=StunDuration;

            if(life==0){
                animator.SetTrigger("death");
            }else{
                animator.SetTrigger("hit");
            }
            
            Destroy(hit.gameObject);
        }

        if(hit.gameObject.tag=="Item"){
            onigiri++;

            if(onigiri==5){
                life++;
                onigiri=0;
            }

            Destroy(hit.gameObject);
        }
    }
}
