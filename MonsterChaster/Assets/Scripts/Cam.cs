using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField] private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //kiem tra xem neu nguoi choi con song thi tiep tuc lenh duoi, con k thi bo qua
        if (!player) //player chet
           return;//neu dung bo qua, neu sai thi tiep tuc lenh ben duoi
        //luu vi tri hien tai cua cam
        tempPos = transform.position;
        //luu vi tri hien tai cua player
        tempPos.x = player.position.x;
        //gioihancam
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;
        //gan vi tri hien tai cua cam la vi tri hien tai cua player
        transform.position = tempPos;
    }
}
