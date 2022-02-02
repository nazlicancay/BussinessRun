using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> vehicles = new List<GameObject>();
    public PlayerCollitions player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVehicleFalse()
    {
        if (player.skate)
        {

        }

    }
}
