using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider front;
    public WheelCollider back;
    public GameObject frontWheel, backWheel;
    Vector3 frontvec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frontvec = frontWheel.transform.localEulerAngles;
        frontvec.y = front.steerAngle;
        frontWheel.transform.localEulerAngles = frontvec;
    }
}
