using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public float rotateMultiplier;
    public float swipeSpeed;
    public float maxLeftX;
    public float maxRightX;
    public float Fspeed;
    public float speed;
    public GameManager gameManager;
    private bool Swipe = false;
    private bool once = true;
   

void Start()
    {
        Fspeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && once)
        {
           gameManager.StartGame();
            once = false;
        }

        if(Swipe)
        {
            //gameManager.StartGame();
        }

        

        if (GameManager.Instance.GameActive)
        {
            if (transform.rotation != Quaternion.identity)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * speed);
            }

            if (GameManager.Instance.GameActive)
            {
                transform.position -= transform.forward * Time.deltaTime *Fspeed;
            }
        }




    }

    public void RotateCharacter(Vector2 position)
    {
        position = position.normalized;
        Quaternion rotation = Quaternion.AngleAxis(position.x * rotateMultiplier, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 2);
    }


    public void InputUpdate(Vector2 delta)
    {
        Swipe = true;
        if (GameManager.Instance.GameActive)
        {
            
            Vector3 newPos = transform.position - new Vector3(delta.x * swipeSpeed * Time.deltaTime, 0, 0);
            newPos.x = Mathf.Clamp(newPos.x, maxRightX, maxLeftX);
            transform.position = newPos;

        }




    }

    public void AddSpeed(int speed)
    {
        Fspeed += speed;
    }

    public void DelJumpSpeed(int speed)
    {
        Fspeed -= speed;

        transform.DOMoveZ( transform.position.z + 1.5f , 1f);
    }

    public void DelSpeed(int speed)
    {
        Fspeed -= speed;
    }
}
