using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform playerTr;

    private Animator anim;
    private int hashHit = Animator.StringToHash("Hit");

    private float hp = 100.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        anim  = GetComponent<Animator>();

        //하이러키뷰(씬뷰)에 있는 모든 게임오브젝트 중에서 "Player" 이름을 갖는 게임오브젝트를 추출(검색)
        //Find ~ 계열의 함수는 반드시 Start, Awake 에서만 사용.
        GameObject playerObj = GameObject.Find("Player");      
        if (playerObj != null) 
        {
            playerTr = playerObj.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.Distance(A, B)   A와 B간의 거리를 반환하는 함수

        //공격로직
        if (Vector3.Distance(transform.position, playerTr.position) <= 2.0f)
        {
            anim.SetBool("isAttack", true);
            agent.isStopped = true; //내비메시에이전트를 정지
        }
        //추적로직
        else if (Vector3.Distance(transform.position, playerTr.position) <= 5.0f)
        {
            agent.SetDestination(playerTr.position);
            agent.isStopped = false; //추적시작

            anim.SetBool("isTrace", true);
            anim.SetBool("isAttack", false);
        }
        else
        {
            anim.SetBool("isTrace", false);
            agent.isStopped = true; //정지
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
            //anim.SetTrigger("Hit"); //Hashtable 검색하는 시간이 소요됨.(X)
            anim.SetTrigger(hashHit); //미리 추출한 해시값을 전달.(O)
            //HP 차감
            hp -= 20.0f; //hp = hp - 20.0f;
            //몬스터 사망여부 판단
            if (hp <= 0.0f)
            {
                MonsterDie();
            }
        }
    }

    private int hashDie = Animator.StringToHash("Die");

    void MonsterDie()
    {
        anim.SetTrigger(hashDie);
    }
}
