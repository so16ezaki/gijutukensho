using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Sensor leftSensor;
    [SerializeField] Sensor rightSensor;
    [SerializeField] int areaSize = 30;

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



        float lspeed = 20 - leftSensor.averageBrightness * 30;
        Vector3 lDirection = transform.right*lspeed;
        frontLeft.AddTorque(lDirection);
        backLeft.AddTorque(lDirection);

        float rspeed = 20 + leftSensor.averageBrightness * 30;
        Vector3 rDirection = new Vector3(rspeed, 0, 0);
        frontRight.AddTorque(rDirection);
        backtRight.AddTorque(rDirection);
    }
}
