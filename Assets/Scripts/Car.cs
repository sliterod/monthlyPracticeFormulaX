using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    private Rigidbody rb;
    [Header("Car Specs")]
    // Use this for initialization

    public float wheelRadious;
	void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // PHYSICS FUNCTIONS //


    //AUDIO / VISUAL FUNCTIONS //


}
