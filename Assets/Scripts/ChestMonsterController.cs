using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterController : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    Transform EndPoint;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 destPos;

    float speed=1.0f;
    float rotateSpeed = 180f;  // 回転速度
    float rotateNum; 

    void Start()
    {
        animator=GetComponent<Animator>();

        startPos=transform.position;
        endPos=EndPoint.position;
        destPos=endPos;
    }

    // Update is called once per frame
    void Update()
    {
        // 端に到達した時の方向転換処理
        if ((destPos - transform.position).magnitude < 0.1f)
        {
            // 回転途中の場合
            if (rotateNum < 180)
            {
                animator.SetBool("WalkFWD", false);
                transform.position = destPos;
 
                float addNum = rotateSpeed * Time.deltaTime;
                rotateNum += addNum;
                transform.Rotate(0, addNum, 0);
                return;
            }
            // 回転し切った場合
            // 次の目的地の設定と回転量のリセット
            else
            {
                destPos = destPos == startPos ? endPos : startPos;
                rotateNum = 0;
            }
        }
 
        // 次の目的地に向けて移動する
        animator.SetBool("WalkFWD", true);
        transform.LookAt(destPos);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
