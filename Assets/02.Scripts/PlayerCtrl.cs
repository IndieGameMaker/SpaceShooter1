using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //다른 모든 스크립트의 Start 함수가 호출되기 전에 제일 먼저 호출된다.
    void Awake()
    {

    }

    //한번 호출됨. 매번 스크립트가 활성화 될때마다 호출되는 함수.
    void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 화면을 랜더링하는 주기마다 호출됨.
    // 호출주기가 불규칙함.
    // 건너뛰는 현상 (프레임 드랍)
    // 항상 최적화에 신경을 써야 되는 함수
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log("h=" + h); 
        Debug.Log("v=" + v);

        //Translate(이동방향 * 속력 * 변위)
        transform.Translate(Vector3.forward * 0.1f * v);    //전진/후진
        transform.Translate(Vector3.right * 0.1f * h);      //좌우이동
        //단위벡터, 정규화벡터
        /*
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.zero    = Vector3(0, 0, 0)
            Vector3.one     = Vector3(1, 1, 1)
        */





        //transform.position += new Vector3(0, 0, 0.1f) * v;
        //transform.position = transform.position + new Vector3(0, 0, 0.1f);
    }

    // 물리엔진이 시뮬레이션 연산을 하는 주기 (0.03초)
    // 정확히 fixedTimeStemp 기준으로 호출됨. (정확한 시간간격으로 호출)
    void FixedUpdate()
    {

    }

    void LateUpdate()
    {

    }

    

}
