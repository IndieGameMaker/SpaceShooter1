using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public AudioClip fireSfx;

    private AudioSource source; //AudioSource 컴포넌트를 저장하기 위한 변수

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //마우스 왼쪽 버튼 클릭할 때 마다
        {
            Fire();
        }    
    }

    void Fire()
    {
        //동적으로 총알을 생성하는 로직
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        //총 발사 음향 실행
        source.PlayOneShot(fireSfx);
        /*
        source.clip = fireSfx;
        source.Play();
        */
    }
}
