﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    //鼠标敏度  
    public float mousesSensity = 4F;

    //上下最大视角(Y视角)  
    public float minYLimit = -90F;
    public float maxYLimit = 90F;

    //左右最大视角(X视角)  
    public float minXLimit = -90F;
    public float maxXLimit = 90F;

    Vector3 m_camRotation;
    void Update()
    {
        //根据鼠标的移动,获取相机旋转的角度
        m_camRotation.x += Input.GetAxis("Mouse X") * mousesSensity;
        //角度限制
        m_camRotation.x = Mathf.Clamp(m_camRotation.x, minXLimit, maxXLimit);
        //m_camRotation.x = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousesSensity;


        m_camRotation.y += Input.GetAxis("Mouse Y") * mousesSensity;
        //角度限制
        m_camRotation.y = Mathf.Clamp(m_camRotation.y, minYLimit, maxYLimit);

        //相机角度随着鼠标旋转  
        transform.localEulerAngles = new Vector3(-m_camRotation.y, m_camRotation.x, 0);
    }

    void Start()
    {

    }
}