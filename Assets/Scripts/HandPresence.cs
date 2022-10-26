using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public GameObject handPrefab;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    private InputDevice targetDevice;
    public InputDeviceCharacteristics controllerCharacteristics;
    public Camera VRCamera;
    private Animator CamAnim;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        CamAnim = VRCamera.GetComponent<Animator>();
        if(devices.Count > 0)
        {
            targetDevice = devices[0];

        }
        spawnedHandModel = Instantiate(handPrefab, transform);
        spawnedHandModel.SetActive(true);
        handAnimator = spawnedHandModel.GetComponent<Animator>();

    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
            Debug.Log("Trigerrring");
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryValue))
        {
            CamAnim.SetBool("Zoom", primaryValue);
        }
        else
        {
            CamAnim.SetBool("Zoom", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateHandAnimation();
    }


}
