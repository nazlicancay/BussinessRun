using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform finalCamTarget;
    public CinemachineVirtualCamera cm;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GameActive)
        {
            cm.transform.DOMove(new Vector3(finalCamTarget.transform.position.x, finalCamTarget.transform.position.y,finalCamTarget.transform.position.z),0.1f);
        }
        
    }
}
