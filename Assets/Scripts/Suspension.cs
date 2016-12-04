using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour {

    public Rigidbody rb;
    private Car carScript;

    [Header("SUSPENSION")]

    public float springForce;
    public float damperForce;
    public float springConstant;
    public float damperConstant;
    public float restLenght;

    private float previouseLenght;
    private float currentLenght;
    private float springVelocity;

    // Use this for initialization
    void Start () {
        carScript = transform.parent.GetComponent<Car> ();

    }

    // Update is called once per frame
    void FixedUpdate() {

    RaycastHit hit;

    if(Physics.Raycast(transform.position, -transform.up,out hit, restLenght + carScript.wheelRadious)){
            previouseLenght = currentLenght;
            currentLenght = restLenght - (hit.distance - carScript.wheelRadious);
            springVelocity = (currentLenght - previouseLenght) / Time.fixedDeltaTime;
            springForce = springConstant * currentLenght;
            damperForce = damperConstant * springVelocity;

            rb.AddForceAtPosition (transform.up * (springForce + damperForce), transform.position);
        }
}


}

