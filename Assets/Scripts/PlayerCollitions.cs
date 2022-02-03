using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RootMotion.FinalIK;


public class PlayerCollitions : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreManager scoreManager;
    public LevelManager levelManager;
    public TimeBarController Timebar;
    public int coinNum;
    public FullBodyBipedIK ık;
    public Transform leftLegTarget, rightLegTarget;
    public Transform leftMotorLegTarget, rightMotorLegTarget;
    public Transform leftMotorArmTarget, rightMotorArmTarget;
    public GameObject Skateleft, SkateRight;
    public PlayerMovement playerMovement;
    public GameObject bicycle;
    public Canvas FailCanvas;
    public GameManager gameManager;
    public GameObject cycle, motor;
    public VehicleController vehicle;
    public bool skateActive;
    public Vector3 handTarget = new Vector3();
    public bool once = true;
    public ParticleSystem confeti;
    public bool popConfeti = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("addtime"))
        {
            Timebar.addTime = true;
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("deltime"))
        {
            Timebar.delTime = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            coinNum += 1;
            Debug.Log("para");
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("cycle"))
        {
            skateActive = false;
            cycle = other.gameObject;
            if(scoreManager.GameScore >= 50)
            {
                bicycle = other.gameObject;
                Skate(false);

                playerMovement.AddSpeed(2);
                gameManager.anim.SetTrigger("idle");
                other.gameObject.transform.parent = transform;
                PlayIK();
            }
            
           

                }

        if (other.gameObject.CompareTag("motor"))
        {
            {
                if(scoreManager.GameScore >= 100)
                {
                    bicycle.gameObject.SetActive(false);

                    Skate(false);
                    playerMovement.AddSpeed(3);
                    gameManager.anim.SetTrigger("tpose");
                    other.gameObject.transform.parent = transform;
                    ık.solver.leftFootEffector.target = leftMotorLegTarget;
                    ık.solver.rightFootEffector.target = rightMotorLegTarget;
                    ık.solver.leftHandEffector.target = leftMotorArmTarget;
                    ık.solver.rightHandEffector.target = rightMotorArmTarget;
                    PlayIK();

                }


            }




        }

        if (other.gameObject.CompareTag("skate"))
        {

            skateActive = true;
            if(scoreManager.GameScore > 30)
            {
                playerMovement.AddSpeed(1);
                Skate(true);

            }


        }

        if (other.gameObject.CompareTag("manHole"))
        {
            
            FailCanvas.gameObject.SetActive(true);
            gameManager.GameActive = false;

        }

        if (other.gameObject.CompareTag("barrier"))
        {
            
            if(cycle.gameObject != null)
            {
                vehicle.SetVehicleFalse(cycle);
                playerMovement.DelJumpSpeed(0);
                Debug.Log("bis");



            }
            if(motor.gameObject != null)
            {
                vehicle.SetVehicleFalse(motor);
                playerMovement.DelJumpSpeed(2);
                Debug.Log("motor");
            }

            if(skateActive)
            {
                skateActive = false;
                Skate(false);
                playerMovement.DelJumpSpeed(1);
                Debug.Log("skate");
            }

        }

        if (other.gameObject.CompareTag("man"))
        {
            if(cycle.gameObject != null)
            {
                vehicle.SetVehicleFalse(cycle);
                playerMovement.DelSpeed(2);



            }
            if(motor.gameObject != null)
            {
                vehicle.SetVehicleFalse(motor);
                playerMovement.DelSpeed(3);
            }

            else
            {
                Skate(false);
                playerMovement.DelSpeed(1);
            }
          



        }

        if (other.gameObject.CompareTag("finish"))
        {
            if (popConfeti)
            {
                confeti.Play();
            }
            if (cycle.gameObject != null)
            {
                playerMovement.Fspeed = 0;

                vehicle.SetVehicleFalseFinish(cycle);
                gameManager.anim.SetTrigger("dance");



            }
            if (motor.gameObject != null)
            {
                playerMovement.Fspeed = 0;

                vehicle.SetVehicleFalseFinish(motor);
                gameManager.anim.SetTrigger("dance");
            }

            if (skateActive)
            {
                playerMovement.Fspeed = 0;

                skateActive = false;
                Skate(false);
                gameManager.anim.SetTrigger("dance");
            }
            gameManager.GameActive = false;

        }

    }

    public void PlayIK()
    {
        ık.solver.leftFootEffector.positionWeight = 1;
        ık.solver.leftFootEffector.rotationWeight = 1;
        ık.solver.rightFootEffector.positionWeight = 1;
        ık.solver.rightFootEffector.rotationWeight = 1;
        ık.solver.leftHandEffector.positionWeight = 1;
        ık.solver.leftHandEffector.rotationWeight = 1;
        ık.solver.rightHandEffector.positionWeight = 1;
        ık.solver.rightHandEffector.rotationWeight = 1;


    }

    public void StopIK()
    {
        ık.solver.leftFootEffector.positionWeight = 0;
        ık.solver.leftFootEffector.rotationWeight = 0;
        ık.solver.rightFootEffector.positionWeight = 0;
        ık.solver.rightFootEffector.rotationWeight = 0;
        ık.solver.leftHandEffector.positionWeight = 0;
        ık.solver.leftHandEffector.rotationWeight = 0;
        ık.solver.rightHandEffector.positionWeight = 0;
        ık.solver.rightHandEffector.rotationWeight = 0;
    }

    public void Skate(bool x)
    {
        Skateleft.gameObject.SetActive(x);
        SkateRight.gameObject.SetActive(x);
        gameManager.anim.SetBool("faster", x);

    }
}
