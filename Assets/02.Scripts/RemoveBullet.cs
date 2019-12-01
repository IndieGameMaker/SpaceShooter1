using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    //충돌이 발생했을 때 한번 호출되는 충돌 콜백함수
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            ContactPoint[] points = coll.contacts;
            Quaternion rot = Quaternion.LookRotation(points[0].normal);

            GameObject obj = Instantiate(sparkEffect, points[0].point, rot);
            Destroy(obj , 0.4f);


            Destroy(coll.gameObject);
        }
    }
}
