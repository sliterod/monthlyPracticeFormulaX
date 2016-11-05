using UnityEngine;
using System.Collections;

public class MockMovement : MonoBehaviour {

    public Transform cube;
    public float accel;
    float ceilAccel;
    float floorAccel;

	// Use this for initialization
	void Start () {
        accel = 0.1f;
        ceilAccel = 2.0f;
        floorAccel = accel;
	}
	
	// Update is called once per frame
	void Update () {
        /*
                if (Input.GetKey(KeyCode.D)) {
                    AccelUp();
                    cube.transform.position = new Vector3(cube.transform.position.x + accel,
                        cube.transform.position.y,
                        cube.transform.position.z);
                }
                if (Input.GetKey(KeyCode.A)) {
                    AccelDown();
                    cube.transform.position = new Vector3(cube.transform.position.x - accel,
                        cube.transform.position.y,
                        cube.transform.position.z);
                }

                if (Input.GetKeyDown(KeyCode.Space)) {
                    cube.transform.position = Vector3.zero;
                    accel = floorAccel;
                }
            }

            void AccelUp(){
                if (accel <= ceilAccel) {
                    accel += 0.05f;
                }
            }

            void AccelDown()
            {
                if (accel >= floorAccel)
                {
                    accel -= 0.05f;
                }*/
    }
}
