using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    /// <summary>
    /// functions for setting the max gas, decresing gas and adding gas
    /// </summary>
    
    #region varaiables
    public Slider slider;
    public int currentTime;
    public bool addTime;
    public bool delTime;

    public float time;


    #endregion



    #region Mono Functions

    private void Awake()
    {
        SetMaxTime(100);
        currentTime = 100;
    }


    void Update()
    {
        time = time + Time.deltaTime;

        if (currentTime <= 0)
        {
           // Fail

        }


        if (addTime)
        {
            AddTime();
        }

        if (delTime)
        {
            DecreseTime();
        }


        if (time > 3)
        {
            DecreseTime();
            time = 0;
        }

    }

    public void SetMaxTime(int maxTime)
    {
        slider.maxValue = maxTime;
        slider.value = maxTime;


    }

    public void SetTime(int time)
    {
        slider.value = time;

        
    }

    public void DecreseTime()
    {
        delTime = false;
        currentTime = currentTime - 4;
        SetTime(currentTime);
    }

    public void AddTime()
    {
        addTime = false;
        currentTime += 6;
        SetTime(currentTime);
        Debug.Log("Added time");

    }


    #endregion




}
