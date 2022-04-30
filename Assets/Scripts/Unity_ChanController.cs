using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_ChanController : MonoBehaviour
{
    const int MinLane=-2;
    const int MaxLane=2;
    const float LaneWidth=1.0f;

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

    void Start()
    {
        animator=GetComponent<Animator>();
        controller=GetComponent<CharacterController>();

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
            // Z方向に常に前進
            float acceleratedZ=moveDirection.z+(accelerationZ*Time.deltaTime);
            moveDirection.z=Mathf.Clamp(acceleratedZ,0,speedZ);

            //X方向は目標のポジションまでの差分の割合で速度を計算
            float ratioX=(targetLane*LaneWidth-transform.position.x)/LaneWidth;
            moveDirection.x=ratioX*speedX;

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


        /* // 前進
        if(Input.GetKey("up")){
            transform.position+=transform.forward*0.01f;
            animator.SetBool("run",true);
        }else{
            animator.SetBool("run",false);
        } */


        /* // 左右回転
        if(Input.GetKey("left")){
            transform.Rotate(0,-1,0);
        }else if(Input.GetKey("right")){
            transform.Rotate(0,1,0);
        } */

        /* // ジャンプ
        if(Input.GetKey("space")){
            animator.SetBool("jump",true);
        }else{
            animator.SetBool("jump",false);
        } */
    }

    // 左のレーンに移動
    public void MoveToLeft(){
        if(controller.isGrounded && targetLane>MinLane) targetLane--;
    }

    // 右のレーンに移動
    public void MoveToRight(){
        if(controller.isGrounded && targetLane<MaxLane) targetLane++;
    }

    public void Jump(){
        if(controller.isGrounded){
            moveDirection.y=speedJump;

            animator.SetTrigger("jump");
        }
    }

    /* // ヒット
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="boss"){
            animator.SetTrigger("hit");
            Destroy(hit.gameObject);
        }
    } */
}
