using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class VehicleController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ParticleSystem> cycleStands = new List<ParticleSystem>();
    public List<ParticleSystem> skateStands = new List<ParticleSystem>();
    public List<ParticleSystem> motorStands = new List<ParticleSystem>();

    public PlayerCollitions player;
    public ScoreManager score;
    public PlayerMovement playerMovement;
    private ParticleSystem ps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score.GameScore > 30)
        {
            foreach (ParticleSystem s in skateStands)
            {
                ChangeStandColorGreen(s);
            }
        }

        if(score.GameScore > 50)
        {
            foreach(ParticleSystem c in cycleStands)
            {
                ChangeStandColorGreen(c);
            }
        }

        if(score.GameScore > 100)
        {
            foreach(ParticleSystem m in motorStands)
            {
                ChangeStandColorGreen(m);
            }
        }
        
    }

    public void SetVehicleFalse(GameObject gm)
    {
        gm.SetActive(false);
        player.StopIK();
        GameManager.Instance.anim.SetTrigger("walk");
       

    }

    public void SetVehicleFalseFinish(GameObject gm)
    {
        gm.SetActive(false);
        player.StopIK();
        GameManager.Instance.anim.SetTrigger("walk");


    }

    public void ChangeStandColorRed(ParticleSystem ps)
    {
        var main = ps.main;
        main.startColor = new Color(91, 253, 162, 50);


    }

    public void ChangeStandColorGreen(ParticleSystem ps)
    {
        var main = ps.main;
        main.startColor = new Color(250, 0, 7, 50);


    }



}


