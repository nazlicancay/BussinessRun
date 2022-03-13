using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class VehicleController : MonoBehaviour
{
    // Start is called before the first frame update
  

    public PlayerCollitions player;
    public ScoreManager score;
    public PlayerMovement playerMovement;
    private ParticleSystem ps;
    public Transform leftLegTarget, rightLegTarget;
    public Transform leftMotorLegTarget, rightMotorLegTarget;
    public Transform leftMotorArmTarget, rightMotorArmTarget;
    public Transform BodyMotorTarget;
    public List<GameObject> tags = new List<GameObject>();

    void Start()
    {
        
    }



    public void SetVehicleFalse(GameObject gm)
    {
        gm.SetActive(false);
        player.StopIK();
        GameManager.Instance.anim.SetBool("Walk", true);

        if (player.Finish)
        {
            GameManager.Instance.anim.SetBool("Dance", false);
        }
       



    }

    public void SetVehicleFalseFinish(GameObject gm)
    {
        gm.SetActive(false);
        player.StopIK();
       // GameManager.Instance.anim.SetBool("Walk", true);
        if (player.Finish)
        {
           // GameManager.Instance.anim.SetBool("Dance", false);
        }



    }

    



}


