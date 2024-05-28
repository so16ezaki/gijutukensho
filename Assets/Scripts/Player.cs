using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region serializefield
    [SerializeField] int areaSize;
    [SerializeField] float pGain;
    [SerializeField] float dGain;
    [SerializeField] float normalSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float sensorValue;
    [SerializeField] float leftspeed;
    [SerializeField] float rightspeed;
    [SerializeField] Sensor leftSensor;
    [SerializeField] Sensor rightSensor;

    [SerializeField] Rigidbody frontRight;
    [SerializeField] Rigidbody frontLeft;
    [SerializeField] Rigidbody backtRight;
    [SerializeField] Rigidbody backLeft;
    #endregion

    float postSensorValue =0;

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
        
        
        // �������m����قǒl���������Ȃ�
        sensorValue = leftSensor.averageBrightness - rightSensor.averageBrightness;//0�̂Ƃ����i�A���̂Ƃ����J�[�u�A���̂Ƃ��E�J�[�u

        float dSpeed = postSensorValue - sensorValue;

        float controllSpeed = sensorValue * pGain + dSpeed * dGain;

        postSensorValue = sensorValue;
        
        leftspeed = Mathf.Clamp(normalSpeed + controllSpeed, minSpeed, maxSpeed);
        rightspeed = Mathf.Clamp(normalSpeed - controllSpeed, minSpeed, maxSpeed);



        SetSpeed(leftspeed, rightspeed);
        //float lspeed = 20 - leftSensor.averageBrightness * 30;
        //Vector3 lDirection = transform.right*lspeed;
        //frontLeft.AddTorque(lDirection);
        //backLeft.AddTorque(lDirection);

        //float rspeed = 20 + leftSensor.averageBrightness * 30;
        //Vector3 rDirection = new Vector3(rspeed, 0, 0);
        //frontRight.AddTorque(rDirection);
        //backtRight.AddTorque(rDirection);
    }

    private void SetSpeed(float left, float right)
    {
        Vector3 Direction = transform.right;//��]�����P�ʃx�N�g��



        frontLeft.angularVelocity = (Direction * left);
        backLeft.angularVelocity = (Direction * left);

        frontRight.angularVelocity = (Direction * right);
        backtRight.angularVelocity = (Direction * right);

    }
}
