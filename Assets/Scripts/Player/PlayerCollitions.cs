using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RootMotion.FinalIK;
using UnityEngine.Events;
using Cinemachine;

public class PlayerCollitions : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreManager scoreManager;
    public LevelManager levelManager;
    public TimeBarController Timebar;

    public float coinNum;

    public FullBodyBipedIK ik;
    public GameObject Skateleft, SkateRight;
    public PlayerMovement playerMovement;
    public GameObject bicycle;
    public GameObject FailCanvas;
    public GameManager gameManager;
    public GameObject cycle, motor;
    public VehicleController vehicle;
    public bool skateActive;
    public Vector3 handTarget = new Vector3();
    public bool once = true;
    public ParticleSystem confeti;
    public bool popConfeti = true;
    public GameObject winCanvas;
   // public BoxCollider bx;
    public bool Finish;
    public GameObject skate;
    private static readonly int Walk = Animator.StringToHash("Walk");
    public GameObject Player;

    public UnityEvent OnCoinCollected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(CONSTANTS.TAGS.ADDTIME))
        {
            Timebar.addTime = true;
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.CompareTag("deltime"))
        {
            Timebar.delTime = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            coinNum += 1;
            scoreManager.GameScore += CONSTANTS.PLAYER.ADDSCORE;
            Debug.Log("para");
            other.gameObject.SetActive(false);
            OnCoinCollected.Invoke();
            
        }

        if (other.gameObject.CompareTag("cycle"))
        {
            if (!bicycle.activeInHierarchy)
            {
                skateActive = false;

                if (scoreManager.GameScore >= 100)
                {
                    scoreManager.GameScore -= 100;
                    cycle.gameObject.SetActive(true);
                    Skate(false);

                    playerMovement.AddSpeed(1);
                    gameManager.anim.SetBool("Walk", false);
                    PlayIK();
                }

            }

        }

        if (other.gameObject.CompareTag("motor"))
        {
            if(!motor.activeInHierarchy)
            {
                skateActive = false;
               
                if (scoreManager.GameScore >= 200)
                {
                    motor.gameObject.SetActive(true);
                    bicycle.gameObject.SetActive(false);
                    cycle.gameObject.SetActive(false);
                    scoreManager.GameScore -= 200;
                    Skate(false);
                    playerMovement.AddSpeed(1.5f);
                    gameManager.anim.SetBool("Tpose", true);
                    ik.solver.leftFootEffector.target = vehicle.leftMotorLegTarget;
                    ik.solver.rightFootEffector.target = vehicle.rightMotorLegTarget;
                    ik.solver.leftHandEffector.target = vehicle.leftMotorArmTarget;
                    ik.solver.rightHandEffector.target = vehicle.rightMotorArmTarget;
                    ik.solver.bodyEffector.target = vehicle.BodyMotorTarget;
                    PlayIK();

                }


            }

        }

        if (other.gameObject.CompareTag("skate"))
        {

            skateActive = true;
            if(scoreManager.GameScore >= 50)
            {
                scoreManager.GameScore -= 50;
                playerMovement.AddSpeed(0.5f);
                Skate(true);

            }


        }

        if (other.gameObject.CompareTag("manHole"))
        {
            
            FailCanvas.gameObject.SetActive(true);
            gameManager.GameActive = false;
            Player.transform.DOMoveY(-5,3f);
            CinemachineVirtualCamera cm = CameraManager.Instance.cm;
            cm.Follow = null;
            cm.LookAt = null;


        }

        if (other.gameObject.CompareTag("barrier"))
        {
            if(playerMovement.Fspeed < 2.5f)
            {
                playerMovement.DelJumpSpeed(0f);
            }
           else
            {
                Vibration.VibratePop();
                gameManager.anim.SetBool("Tpose", false);
                if (cycle.gameObject.activeInHierarchy)
                {
                    vehicle.SetVehicleFalse(cycle);
                    playerMovement.DelJumpSpeed(1f);
                    Debug.Log("bis");

                }

                if (motor.gameObject.activeInHierarchy)
                {
                    vehicle.SetVehicleFalse(motor);
                    playerMovement.DelJumpSpeed(1.5f);
                    Debug.Log("motor");
                }

                if (skate.gameObject.activeInHierarchy)
                {
                    skateActive = false;
                    Skate(false);
                    if (playerMovement.Fspeed > 2)
                        playerMovement.DelJumpSpeed(0.5f);
                    Debug.Log("skate");
                }

            }
        }

        if (other.gameObject.CompareTag("man"))
        {
            if (playerMovement.Fspeed > 2)
            {
                if (cycle.gameObject.activeInHierarchy)
                {
                    vehicle.SetVehicleFalse(cycle);
                    playerMovement.DelSpeed(1);
                    
                }

                if (motor.gameObject.activeInHierarchy)
                {
                    vehicle.SetVehicleFalse(motor);
                    playerMovement.DelSpeed(1.5f);
                }
                
                if(skate.gameObject.activeInHierarchy)
                {
                    Skate(false);
                    playerMovement.DelSpeed(0.5f);
                }

               
            }
        }

        if (other.gameObject.CompareTag("finish"))
        {
            Finish = true;
            gameManager.anim.SetBool(Walk, false);
            gameManager.anim.SetBool("Tpose", false);

            if (popConfeti)
            {
                confeti.Play();

            }
            if (cycle.gameObject != null)
            {
                playerMovement.Fspeed = 0;

                vehicle.SetVehicleFalseFinish(cycle);
               // bx.enabled = false;

                gameManager.anim.SetBool("Dance", true);



            }
            if (motor.gameObject != null)
            {
                playerMovement.Fspeed = 0;

                vehicle.SetVehicleFalseFinish(motor);
                //bx.enabled = false;

                gameManager.anim.SetBool("Dance", true);

            }

            if (skateActive)
            {
                playerMovement.Fspeed = 0;

                skateActive = false;
                Skate(false);
                //bx.enabled = false;

                gameManager.anim.SetBool("Dance", true);

            }
            gameManager.GameActive = false;
            winCanvas.gameObject.SetActive(true);

        }

    }

    public void PlayIK()
    {
        ik.solver.leftFootEffector.positionWeight = 1;
        ik.solver.leftFootEffector.rotationWeight = 1;
        ik.solver.rightFootEffector.positionWeight = 1;
        ik.solver.rightFootEffector.rotationWeight = 1;
        ik.solver.leftHandEffector.positionWeight = 1;
        ik.solver.leftHandEffector.rotationWeight = 1;
        ik.solver.rightHandEffector.positionWeight = 1;
        ik.solver.rightHandEffector.rotationWeight = 1;
        ik.solver.bodyEffector.positionWeight = 1;


    }

    public void StopIK()
    {
        ik.solver.leftFootEffector.positionWeight = 0;
        ik.solver.leftFootEffector.rotationWeight = 0;
        ik.solver.rightFootEffector.positionWeight = 0;
        ik.solver.rightFootEffector.rotationWeight = 0;
        ik.solver.leftHandEffector.positionWeight = 0;
        ik.solver.leftHandEffector.rotationWeight = 0;
        ik.solver.rightHandEffector.positionWeight = 0;
        ik.solver.rightHandEffector.rotationWeight = 0;
        ik.solver.bodyEffector.positionWeight = 0;

    }

    public void Skate(bool x)
    {
        Skateleft.gameObject.SetActive(x);
        gameManager.anim.SetBool("faster", x);

    }
}
