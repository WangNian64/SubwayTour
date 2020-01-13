using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //特殊情况（上楼梯）
    public GameObject Louti1Start;
    public GameObject Louti2Start;
    public GameObject Louti1End;
    public GameObject Louti2End;
    private bool UpStairing = false;
    public float minDis2Louti = 100f;
    //移动速度
    public float MoveSpeed = 200f;
    public float UpSpeed = 200f;

    //旋转速度
    public float RotateSpeed = 4f;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (UpStairing == true)
        //{
        //    UpStair();
        //}
        if (Input.GetKey(KeyCode.W))//前
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))//后
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * Time.deltaTime * -MoveSpeed);
        }
        if (Input.GetKey(KeyCode.Space))//上
        {
            rigidbody.MovePosition(rigidbody.position + transform.up * Time.deltaTime * UpSpeed);
        }
        if (Input.GetKey(KeyCode.A))//左转
        {
            transform.Rotate(Vector3.up, -RotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))//右转
        {
            transform.Rotate(Vector3.up, RotateSpeed);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //启动外部程式
            string exePath = @"C:\Users\StaticWind\Desktop\SubwayTour\ViewTest.exe";
            Process.Start(exePath); 
        }
    }

    public void UpStair()
    {
        transform.position = Vector3.MoveTowards(transform.position, Louti1End.transform.position, MoveSpeed * Time.deltaTime);
        if (transform.position == Louti1End.transform.position)
        {
            UpStairing = false;
        }
    }
}
