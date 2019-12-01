using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class : 변수와 함수의 집합
[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
    //public AnimationClip[] dies;
}

public class PlayerCtrl : MonoBehaviour
{
    public PlayerAnim playerAnim;
    public float moveSpeed = 8.0f;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.Play(playerAnim.idle.name); //"Idle"
    }

    // 화면을 랜더링하는 주기마다 호출됨.
    // 호출주기가 불규칙함.
    // 건너뛰는 현상 (프레임 드랍)
    // 항상 최적화에 신경을 써야 되는 함수
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        //벡터의 덧셈연산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        moveDir = moveDir.normalized; //벡터의 정규화: 크기를 1로 변경한 벡터를 산출
        //이동처리
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);
        //회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * 80.0f * r);

        SetAnimation(v, h);
    }

    //애니메이션 처리를 위한 함수
    void SetAnimation(float v, float h)
    {
        if (v >= 0.1f) //전진
        {
            anim.CrossFade(playerAnim.runForward.name , 0.3f);
        }
        else if (v <= -0.1f) //후진
        {
            anim.CrossFade(playerAnim.runBackward.name, 0.3f);
        }
        else if (h >= 0.1f) //오른쪽으로 이동
        {
            anim.CrossFade(playerAnim.runRight.name, 0.3f);
        }
        else if (h <= -0.1f) //왼쪽으로 이동
        {
            anim.CrossFade(playerAnim.runLeft.name, 0.3f);
        }
        else //아이들링
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }
    }
    

}
