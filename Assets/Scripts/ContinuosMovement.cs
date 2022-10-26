using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuosMovement : MonoBehaviour
{
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController characterController;
    public float movSpeed = 10f;
    private XROrigin rig;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        characterController.Move(direction * Time.deltaTime * movSpeed);
    }
}
