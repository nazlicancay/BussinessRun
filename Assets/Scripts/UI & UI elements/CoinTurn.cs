using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTurn : MonoBehaviour
{
    private float Speed = 40f;

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 1f, 0) * Speed * Time.deltaTime;
    }
}
