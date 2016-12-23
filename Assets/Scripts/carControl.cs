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
    private bool braked  = false;
    public float maxBrakeTorque = 100000000000000000;
    bool isBreaking;
    bool isGas;
    float currentSpeed;
    float topSpeed = 150;
    float maxReverseSpeed  = 50;
    float decellarationSpeed = 300;
    float lowestSteerAtSpeed = 50;
    float lowSpeedSteerAngel = 10;
    float highSpeedSteerAngel = 1;
    float myForwardFriction;
    float mySidewayFriction;
    float slipForwardFriction;
    float slipSidewayFriction;

    RaceState raceState;
    Tachometer tachometer;
    
    public void values()
    {
     myForwardFriction = wheelRR.forwardFriction.stiffness;
     mySidewayFriction = wheelRR.sidewaysFriction.stiffness;
     slipForwardFriction = 0.05f;
     slipSidewayFriction = 0.085f;
    }

    // Use this for initialization
    void Start () {
        values();
        com = new Vector3(0.0f,-0.9F,0.5f);

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;

        wheelRL.brakeTorque = 0;
        wheelRR.brakeTorque = 0;
        
        isGas = true;

        raceState = GameObject.Find("Gamestate")
            .GetComponent<RaceState>();

        tachometer = GameObject.Find("ManagerUI")
            .GetComponent<Tachometer>();
    }

    void FixedUpdate()
    {
        if (raceState.CurrentState == Gamestate.race)
        {
            Control();
            HandBrake();
        }
        
    }
    // Update is called once per frame
    void Update () {

        

        //HandBrake();

        /*

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
        */
    }
    public void Control()
    {
        currentSpeed = 2 * 22 / 7 * wheelRL.radius * wheelRL.rpm * 60 / 1000;
        currentSpeed = Mathf.Round(currentSpeed);

        if (currentSpeed < topSpeed && currentSpeed > -maxReverseSpeed && !braked)
        {
            //Accelerate
            wheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
            wheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");
        }
        else
        {
            wheelRR.motorTorque = 0;
            wheelRL.motorTorque = 0;
            //Turn
            //wheelFL.steerAngle = 30 * Input.GetAxis("Horizontal");
            //wheelFR.steerAngle = 30 * Input.GetAxis("Horizontal");
        }
        if (Input.GetButton("Vertical") == false)
        {
            wheelRR.brakeTorque = decellarationSpeed;
            wheelRL.brakeTorque = decellarationSpeed;
        } else {
            wheelRR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
        }
        var speedFactor = rb.velocity.magnitude / lowestSteerAtSpeed;
        var currentSteerAngel = Mathf.Lerp(lowSpeedSteerAngel, highSpeedSteerAngel, speedFactor);
        currentSteerAngel *= Input.GetAxis("Horizontal");
        wheelFL.steerAngle = currentSteerAngel;
        wheelFR.steerAngle = currentSteerAngel;

        //Changing speed
        tachometer.ChangeSpeedNumber(currentSpeed);
    }

    public void SetRearSlip(float currentForwardFriction, float currentSidewayFriction)
    {
       // wheelRR.forwardFriction.stiffness 
       // wheelRR.forwardFriction.stiffness = currentForwardFriction;
       // wheelRL.forwardFriction.stiffness = currentForwardFriction;
       // wheelRR.sidewaysFriction.stiffness = currentSidewayFriction;
       // wheelRL.sidewaysFriction.stiffness = currentSidewayFriction;
    }

    public void HandBrake()
    {
        //Debug.Log("Breaking...");
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Breaking...");
            braked = true;
        }
        else
        {
            braked = false;
        }
        if (braked)
        {
            if (currentSpeed > 1)
            {
                wheelFR.brakeTorque = maxBrakeTorque;
                wheelFL.brakeTorque = maxBrakeTorque;
                wheelRR.motorTorque = 0;
                wheelRL.motorTorque = 0;
                SetRearSlip(slipForwardFriction, slipSidewayFriction);
            }
            else if (currentSpeed < 0)
            {
                wheelRR.brakeTorque = maxBrakeTorque;
                wheelRL.brakeTorque = maxBrakeTorque;
                wheelRR.motorTorque = 0;
                wheelRL.motorTorque = 0;
                SetRearSlip(1, 1);
            }
            else
            {
               // SetRearSlip(1, 1);
            }
           if (currentSpeed < 1 || currentSpeed > -1){
               // backLightObject.renderer.material = idleLightMaterial;
            }else {
              //  backLightObject.renderer.material = brakeLightMaterial;
            }
        }
        else
        {
            wheelFR.brakeTorque = 0;
            wheelFL.brakeTorque = 0;
           SetRearSlip(myForwardFriction, mySidewayFriction);
        }
    }

 


}









