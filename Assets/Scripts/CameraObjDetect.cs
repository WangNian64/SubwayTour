using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CameraObjDetect : MonoBehaviour
{
    private Vector3 screenCenterPoint = new Vector3(Screen.width/2, Screen.height/2, 0);
    private Dictionary<string, string> ObjNameContentDic;

    public Text ObjTipText;
    public float minTipShowDistance = 700f;

    // Start is called before the first frame update
    void Start()
    {
        ObjNameContentDic = new Dictionary<string, string>();
        ObjNameContentDic.Add("十二封广告牌", "地铁灯箱广告牌，3m*1.5m");
        ObjNameContentDic.Add("四封广告牌（三块牌一组）", "地铁灯箱广告牌，1m*1.5m");
        ObjNameContentDic.Add("LED电视广告牌", "利用发光二极管拼成的广告字样或者图片");
        ObjNameContentDic.Add("四封广告牌", "地铁灯箱广告牌，1m*1.5m");
        ObjNameContentDic.Add("小广告牌", "（根据场景设定）");
        ObjNameContentDic.Add("自动提款机", "XX银行终端设备，提供24小时存款、取款等功能");
        ObjNameContentDic.Add("自动售卖机", "一种能根据投入的钱币自动付货的机器");
        ObjNameContentDic.Add("讯息显示屏（单面）", "一种单面显示讯息的电子设备（根据具体设施增加相关信息）");
        ObjNameContentDic.Add("讯息显示屏（双面）", "一种双面显示讯息的电子设备（根据具体设施增加相关信息）");
        ObjNameContentDic.Add("摄像头（定焦）", "一种摄像设备，用于监测XX（站台、通道、进出站口、闸机等）处的客流状况");
        ObjNameContentDic.Add("摄像头（具云台）", "一种摄像设备，可以改变焦距来调整视角大小，用于监测XX（站台、通道、进出站口、闸机等）处的客流状况");
        ObjNameContentDic.Add("紧急停车按钮", "列车运行在紧急状态时为了使列车以最快的速度停车施加的制动");
        ObjNameContentDic.Add("消防设备", "消火栓：设置在消防给水管网上的消防供水装置，由阀、出水口和壳体等组成。按其水压可分为低压式和高压式两种。灭火器：一种可携式灭火工具。灭火器内放置化学物品，用以救灭火灾。");
        ObjNameContentDic.Add("手动报警（按钮）", "用于火灾报警。当火灾探测器没有探测时，人员手动按下报告火灾。");
        ObjNameContentDic.Add("安全门系统", "又称站台屏蔽门，设置在站台边缘，将乘客候车区与列车运行区相互隔离，并与列车门相对应。");
        ObjNameContentDic.Add("安检仪器（安检x光机）", "依靠X射线来实现，是一种借助于输送带将被检查行李送入X射线检查通道而完成检查的电子设备。");
        ObjNameContentDic.Add("导流栏杆", "用于引导客流方向的栏杆。");
        ObjNameContentDic.Add("导向标识系统", "用于指示通往不同功能区的信息标志系统，以图形、文字等形式展示");
        ObjNameContentDic.Add("乘客信息系统", "提供实时车站信息的系统，如当前时间、列车到站时间、列车满载率等");
        ObjNameContentDic.Add("闸机", "又称自动检票机，在付费区出入口处自动检验车票的有效性并为乘客放行的设备");
        ObjNameContentDic.Add("钟", "又称时钟系统，为运营线路的各系统及相关人员、乘客提供统一标准时间的系统设备");
        ObjNameContentDic.Add("站台座椅", "放置在地铁站台处，供乘客休息的座椅");
        ObjNameContentDic.Add("楼梯", "站台、站厅层间的垂直连接构件");
        ObjNameContentDic.Add("电梯", "分垂直电梯、自动扶梯两种。（根据具体设备显示）");
        ObjNameContentDic.Add("售票亭", "又称票务中心，集中管理轨道交通票证和票款业务的自动化设施和场所");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        object ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        RaycastHit hit;                                                    //射线对象是：结构体类型（存储了相关信息）
        bool isHit = Physics.Raycast((Ray)ray, out hit);            //发出射线检测到了碰撞  isHit返回的是 一个bool值

        if (isHit)
        {
            GameObject hitterObj = hit.collider.gameObject;
            string hitterTag = hitterObj.tag;
            float hitterDistance = Vector3.Distance(hit.point, Camera.main.transform.position);
            if (hitterDistance <= minTipShowDistance)
            {
                ShowObjTip(hitterTag);
            }
            else
            {
                ClearObjTip();
            }
        }
        else
        {
            ClearObjTip();
        }
    }
    public void ShowObjTip(string hitterTag)
    {
        string tipContent = "";
        try
        {
            ObjNameContentDic.TryGetValue(hitterTag, out tipContent);
        }
        catch (Exception e)
        {

        }
        if (tipContent != "" && tipContent != null)
        {
            ObjTipText.text = hitterTag + "：" + tipContent;

        }
    }
    public void ClearObjTip()
    {
        ObjTipText.text = "";
    }
}
