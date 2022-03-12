using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Transform tr;
    Vector3 move;
    public float moveSpeed = 1f;
    void Start()
    {
        tr =transform;
    }

    private void FixedUpdate()
    {
        tr.transform.position += move * Time.deltaTime * moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        move = new Vector3 (h,0,v);
    }

}
