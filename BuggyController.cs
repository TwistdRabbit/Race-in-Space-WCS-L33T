using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggyController : MonoBehaviour
{
    //declaring the wheels and the wheel joints that I added to the buggy itself
    public WheelJoint2D frontTire;
    public WheelJoint2D middleTire;
    public WheelJoint2D backTire;

    //the motors that will allow me to move the car forward backwards
    JointMotor2D motorFront;
    JointMotor2D motorBack;
    public float speedF;
    public float speedB;

    public float torqueF;
    public float torqueB;

    public bool TractionFront = true;
    public bool TractionBack = true;
    public float buggyRotationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetAxisRaw("Horizontal")>0)
        {
            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * -1;
                motorFront.maxMotorTorque = torqueF;
                frontTire.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * -1;
                motorBack.maxMotorTorque = torqueF;
                backTire.motor = motorBack;
            }

        }else if (Input.GetAxisRaw("Horizontal")<0)
        {
            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * -1;
                motorFront.maxMotorTorque = torqueB;
                frontTire.motor = motorFront;
            }
            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * -1;
                motorBack.maxMotorTorque = torqueB;
                backTire.motor = motorBack;
            }
        }
        else
        {
            backTire.useMotor = false;
            frontTire.useMotor = false;
            // so the car stops if there is no movement.
        }
        
        //flipping car by pressing up down to allow players to get over certain slopes. we can use it or not.
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            GetComponent<Rigidbody2D>().AddTorque(buggyRotationSpeed * Input.GetAxisRaw("Vertical") * -1);
        }


    }
   
}
