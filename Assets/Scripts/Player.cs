using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] int areaSize = 30;
    [SerializeField] float sensorValue = 0;
    [SerializeField] float leftspeed = 0;
    [SerializeField] float rightspeed = 0;
    [SerializeField] Sensor leftSensor;
    [SerializeField] Sensor rightSensor;

    [SerializeField] Rigidbody frontRight;
    [SerializeField] Rigidbody frontLeft;
    [SerializeField] Rigidbody backtRight;
    [SerializeField] Rigidbody backLeft;



    public int AreaSize { get { return areaSize; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(! Input.GetKeyDown(KeyCode.Escape)) 
        { 
        // 黒を検知するほど値が小さくなる
        sensorValue = leftSensor.averageBrightness - rightSensor.averageBrightness;//0のとき直進、負のとき左カーブ、正のとき右カーブ

        leftspeed = Mathf.Clamp(2 +sensorValue*10,-10,10);
        rightspeed = Mathf.Clamp(2 - sensorValue*10, -10, 10);
       
        }
        else
        {
            Debug.Log("kita");
            switch (Input.GetAxis("Horizontal"))
            {
                case 1:
                    leftspeed = 0;
                    rightspeed = 1;
                    break;
                case -1:
                    leftspeed = 1;
                    rightspeed = 0;
                    break;
                default:
                    leftspeed = 0;
                    rightspeed = 0;
                    break;
            }
        }

        AddTorque(leftspeed, rightspeed);
        //float lspeed = 20 - leftSensor.averageBrightness * 30;
        //Vector3 lDirection = transform.right*lspeed;
        //frontLeft.AddTorque(lDirection);
        //backLeft.AddTorque(lDirection);

        //float rspeed = 20 + leftSensor.averageBrightness * 30;
        //Vector3 rDirection = new Vector3(rspeed, 0, 0);
        //frontRight.AddTorque(rDirection);
        //backtRight.AddTorque(rDirection);
    }

    private void AddTorque(float left,float right)
    {
        Vector3 Direction = transform.right;//回転方向単位ベクトル

        

        frontLeft.angularVelocity = (Direction * left);
        backLeft.angularVelocity = (Direction * left);

        frontRight.angularVelocity = (Direction * right);
        backtRight.angularVelocity = (Direction * right);

    }
}
