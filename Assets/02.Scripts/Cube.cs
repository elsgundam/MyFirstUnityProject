using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //필드의 인스펙터창 노출 설정
    //public : 외부 클래스 접근 가능, 인스펙터창 노출함
    //private : 외부 클래스 접근 불가, 인스펙터창 노출 안함
    //[HideInInspector] public : 외부 클래스 접근 가능, 인스펙터창 노출 안함
    //[SerializeField] private : 외부 클래스 접근 불가, 인스펙터창 노출 함

    //this 키워드
    //객체 자신을 반환하는 키워드
    public float speed = 1f;
    public int a = 3;
    private Transform tr;
    Vector3 move;


    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log(this);
        Debug.Log(this.gameObject);
        Debug.Log(gameObject);
        //tr = this.gameObject.GetComponent<Transform>(); // this또는 this.gameObject 생략 또는 tr = transform ; 의 형태로 표현 가능
        tr = transform;
    }

    void Start()
    {
        tr.position = Vector3.zero; //최고속도
        //GetComponent<Transform>().position = Vector3.zero;//MonoBehaviour안의 GetComponent에 접근 *캐시 메모리 소모
        //gameObject.GetComponent<Transform>().position = Vector3.zero;//MonoBehaviour안의 GetComponent에 접근 *캐시 메모리 소모
        //this.gameObject.GetComponent<Transform>().position = Vector3.zero;//MonoBehaviour안의 GetComponent에 접근 *캐시 메모리 소모
    }
    internal void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log($"h = {h} ,v = {v}");
        float speed = 1f;
        move = new Vector3(h,0,v);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position 변경시에는 
        //position 의 프레임당 변화 량을 더해주어야 된다.
        //시간당 위치 변화량(속도) = 거리/시간 |기준 = 1s
        //프레임 시간당 변화량(프레임 단위 속도) = 위치 변화량 / 프레임 시간
        //위치 = 프레임 시간당 위치변화량 * 프레임 시간
        //
        tr.position += move * Time.fixedDeltaTime;
        

    }
}
