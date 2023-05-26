using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Camerashake : MonoBehaviour
{
    public CinemachineImpulseSource CinemachineImpulseSource;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
        }
    }
}
