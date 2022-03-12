using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform tr;
    private List<Transform> players = new List<Transform>();
    public int targetIndex = 0;
    public Vector3 offset = new Vector3 (0, 2, -4);

    public Camera mainCamera;
    public Camera subCamera;
    public Camera thirdCamera;
    public Camera lastCamera;
    public PlayerMove horse;

    private void Awake()
    {
        tr = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
        thirdCamera.enabled = false;
        lastCamera.enabled = true;

        foreach (var item in GamePlay.instance.players)
        {
            players.Add(item.transform);
        }
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }
    // Update is called once per frame
    void Update()
    {
        if (GamePlay.instance.onPlay)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SwitchTarget();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                thirdCamera.enabled = true;
                mainCamera.enabled = false;
                subCamera.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                subCamera.enabled = true;
                mainCamera.enabled = false;
                thirdCamera.enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thirdCamera.enabled = false;
                mainCamera.enabled = true;
                subCamera.enabled = false;
            }
        }
        else if (GamePlay.instance.players.Count==0)
        {           
           thirdCamera.enabled = false;
           mainCamera.enabled = false;
           subCamera.enabled = false;                
        }
    }
    void SwitchTarget()
    {
        targetIndex++;
        if (targetIndex > players.Count - 1)
        {
            targetIndex=0;
        }
    }
    private void FollowTarget()
    {
        tr.position = GamePlay.instance.players[targetIndex].transform.position + offset;
    }
}
