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
        anim.SetTrigger("walk");
    }

    public void StartLevel()
    {
        player.transform.DORotate(new Vector3(0, 0, 180f), 1f);
        GameActive = true;
    }

   
   


}
