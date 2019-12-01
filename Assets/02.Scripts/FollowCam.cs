using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;  //따라가야할 주인공의 Transform 컴포넌트
    public float distance = 10.0f;
    public float height   = 5.0f;
    public float damping  = 2.0f; //민감도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = (-targetTr.forward * distance) + (Vector3.up * height);
        //Vector3.Lerp(현재 위치, 이동할 위치, 민감도)
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * damping);
    }
}
