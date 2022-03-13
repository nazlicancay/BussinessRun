using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool GameActive;
    public bool GameEnded;
    public GameObject StartImange;
    public GameObject levelObj;
    public GameObject player;
    public Animator anim;
    public PlayerMovement playerSpeed;
   
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void StartGame()
    {
        StartImange.SetActive(false);
        GameActive = true;
        anim.SetBool("Walk", true);
        playerSpeed.Fspeed = 2;
    }

    public void StartLevel()
    {
        player.transform.DORotate(new Vector3(0, 0, 180f), 1f);
        GameActive = true;
        playerSpeed.Fspeed = 2;

    }

    public void StartNextLevel()
    {
        StartImange.SetActive(false);
        GameActive = true;
       
        playerSpeed.Fspeed = 2;


    }





}
