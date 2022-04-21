using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_ChanController : MonoBehaviour
{
    Animator animator;
    // CharacterController controller;

    void Start()
    {
        animator=GetComponent<Animator>();
        // controller=GetComponent<CharacterController>();
    }

    void Update()
    {
        // 前進
        if(Input.GetKey("up")){
            transform.position+=transform.forward*0.01f;
            animator.SetBool("run",true);
        }else{
            animator.SetBool("run",false);
        }

        // 左右回転
        if(Input.GetKey("left")){
            transform.Rotate(0,-1,0);
        }else if(Input.GetKey("right")){
            transform.Rotate(0,1,0);
        }

        /* // ジャンプ デバッグ用
        if(Input.GetKeyDown("space")) Jump(); */

        // ジャンプ
        if(Input.GetKey("space")){
            animator.SetBool("jump",true);
        }else{
            animator.SetBool("jump",false);
        }
    }

    /*// ジャンプ
    public void Jump(){
        if(controller.isGrounded){
            animator.SetTrigger("jump");
        }
    }

    // ヒット
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="boss"){
            animator.SetTrigger("hit");
            Destroy(hit.gameObject);
        }
    } */
}
