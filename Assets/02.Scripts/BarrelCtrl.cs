using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET") == true)
        {
            //hitCount = hitCount + 1;  --> ++hitCount;
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        //rb.AddForce(Vector3.up * 1200.0f);
        //AddExplosionForce(횡 폭발력, 폭발원점, 폭발반경, 수직 폭발력)
        rb.AddExplosionForce(1200.0f, transform.position, 20.0f, 1500.0f);
    }

}
