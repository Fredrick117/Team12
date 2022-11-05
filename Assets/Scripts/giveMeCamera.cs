using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class giveMeCamera : MonoBehaviour
{
    public GameObject camera;
    public XRController controller;

  

    private void Update()
    {
        CommonInput();
        // OculusTouch();
    }

    private void CommonInput()
    {

        controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool secondary);
        if (secondary)
        {
           
            camera.transform.position = this.transform.position;
        }
       
    }

}
