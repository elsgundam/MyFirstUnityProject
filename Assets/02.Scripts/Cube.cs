using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //�ʵ��� �ν�����â ���� ����
    //public : �ܺ� Ŭ���� ���� ����, �ν�����â ������
    //private : �ܺ� Ŭ���� ���� �Ұ�, �ν�����â ���� ����
    //[HideInInspector] public : �ܺ� Ŭ���� ���� ����, �ν�����â ���� ����
    //[SerializeField] private : �ܺ� Ŭ���� ���� �Ұ�, �ν�����â ���� ��

    //this Ű����
    //��ü �ڽ��� ��ȯ�ϴ� Ű����
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
        //tr = this.gameObject.GetComponent<Transform>(); // this�Ǵ� this.gameObject ���� �Ǵ� tr = transform ; �� ���·� ǥ�� ����
        tr = transform;
    }

    void Start()
    {
        tr.position = Vector3.zero; //�ְ�ӵ�
        //GetComponent<Transform>().position = Vector3.zero;//MonoBehaviour���� GetComponent�� ���� *ĳ�� �޸� �Ҹ�
        //gameObject.GetComponent<Transform>().position = Vector3.zero;//MonoBehaviour���� GetComponent�� ���� *ĳ�� �޸� �Ҹ�
        //this.gameObject.GetComponent<Transform>().position = Vector3.zero;//MonoBehaviour���� GetComponent�� ���� *ĳ�� �޸� �Ҹ�
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
        //position ����ÿ��� 
        //position �� �����Ӵ� ��ȭ ���� �����־�� �ȴ�.
        //�ð��� ��ġ ��ȭ��(�ӵ�) = �Ÿ�/�ð� |���� = 1s
        //������ �ð��� ��ȭ��(������ ���� �ӵ�) = ��ġ ��ȭ�� / ������ �ð�
        //��ġ = ������ �ð��� ��ġ��ȭ�� * ������ �ð�
        //
        tr.position += move * Time.fixedDeltaTime;
        

    }
}
