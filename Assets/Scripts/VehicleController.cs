using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class VehicleController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> vehicles = new List<GameObject>();
    public PlayerCollitions player;
    public PlayerMovement playerMovement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVehicleFalse(GameObject gm)
    {
        gm.SetActive(false);
        player.StopIK();
        GameManager.Instance.anim.SetTrigger("walk");
       

    }



}


