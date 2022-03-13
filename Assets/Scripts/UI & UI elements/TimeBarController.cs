using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
public class TimeBarController : MonoBehaviour
{
    /// <summary>
    /// functions for setting the max gas, decresing gas and adding gas
    /// </summary>
    
    #region varaiables
    public Slider slider;
    public int MaxTime = 100;
    public float currentTime;
    public float CurrentTimeIncrase = 4f;
    public float CurrentTimeDecrase = 4f;
    public bool addTime;
    public bool delTime;


    public float time;


    #endregion



    #region Mono Functions

    private void Awake()
    {
        
        SetMaxTime();
        currentTime = MaxTime;
    }


    void Update()
    {
      
        if (GameManager.Instance.GameActive)
        {
            SetTime(currentTime);
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                Debug.Log("fsafaf");
                UIManager.Instance.failpanel.SetActive(true);
                GameManager.Instance.GameActive = false;
                GameManager.Instance.anim.SetBool("Defated", true);
            }


            if (addTime)
            {
                AddTime();
            }

            if (delTime)
            {
                DeleteTime();
            }

            if (currentTime > MaxTime)
            {
                Debug.Log("Reaced Max Time");
                currentTime = MaxTime;
                return;
            }
        }
    }

    public void SetMaxTime()
    {
        slider.maxValue = MaxTime;
        slider.value = MaxTime;
    }

    public void SetTime(float time)
    {
        if (GameManager.Instance.GameActive)
        {
            slider.value = time;

        }
    }

    public void DecreseTime()
    {
      
        delTime = false;
        currentTime = currentTime -= Time.deltaTime;
        SetTime(currentTime);
       
    }
    [Button("AddTime")]
    public void AddTime()
    {
        if(currentTime < 100)
        {
          addTime = false;
          currentTime += CurrentTimeIncrase;
          SetTime(currentTime);
          Debug.Log("Added time");
        }
        

    }

    public void DeleteTime()
    {
 
         delTime = false;
         currentTime -= CurrentTimeDecrase;
         SetTime(currentTime);
         Debug.Log("ifdsisdg");
    }


    #endregion




}
