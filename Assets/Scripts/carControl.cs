using UnityEngine;
using System.Collections;

public class carControl : MonoBehaviour {


    public  WheelCollider wheelFL;
    public  WheelCollider wheelFR;
    public  WheelCollider wheelRL;
    public  WheelCollider wheelRR;
    public  float maxTorque = 50000;
    public float accelFactor = 5.0f;
    public  Rigidbody rb;
    public float breaking = 0;
    public Vector3 com;

    bool isBreaking;
    bool isGas;


    // Use this for initialization
    void Start () {

        com = new Vector3(0.0f,-0.9F,0.5f);

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;

        wheelRL.brakeTorque = 0;
        wheelRR.brakeTorque = 0;

        isGas = true;
    }
	
	// Update is called once per frame
	void Update () {



   

        //Accelerate
        wheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
         wheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");

        //Turn
            wheelFL.steerAngle = 30 * Input.GetAxis("Horizontal");
            wheelFR.steerAngle = 30 * Input.GetAxis("Horizontal");
        



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Breaking...");
            //accelFactor = 0.0f;
            //maxTorque = 0.0f;
            //isBreaking = true;
            //wheelRR.motorTorque = 0.0f;
            //wheelRL.motorTorque = 0.0f;
            wheelRL.brakeTorque = 50000000.0f;
            wheelRR.brakeTorque = 50000000.0f;
            wheelFL.brakeTorque = 50000000.0f;
            wheelFR.brakeTorque = 50000000.0f;

            //wheelRL.enabled = false;
            //wheelRR.enabled = false;
            //wheelFL.enabled = false;
            //wheelFR.enabled = false;
        }
        


        }
}
