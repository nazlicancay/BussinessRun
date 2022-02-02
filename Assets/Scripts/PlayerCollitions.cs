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


    public GameManager gameManager;

    public Vector3 handTarget = new Vector3();
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
            Skate(false);
            playerMovement.AddSpeed(2);
            gameManager.anim.SetTrigger("idle");
            other.gameObject.transform.parent = transform;
            PlayIK();

                }

        if (other.gameObject.CompareTag("motor"))
        {
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

        if (other.gameObject.CompareTag("skate"))
        {
            playerMovement.AddSpeed(1);
            Skate(true);
           
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

    public void Skate(bool x)
    {
        Skateleft.gameObject.SetActive(x);
        SkateRight.gameObject.SetActive(x);

    }
}
