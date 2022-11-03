using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{

    public InputActionReference shutterAction = null;
    public InputActionProperty lowerShutterSpeed;
    public InputActionProperty increaseShutterSpeed;

    [SerializeField] private TextMeshProUGUI lowShutterSpeedUI;
    [SerializeField] private TextMeshProUGUI highShutterSpeedUI;

    public GameObject go_rightHand;

    Camera cam;
    Plane[] cameraFrustum;
    Collider col;

    float interval = 0.1f;

    private float timeStamp = Mathf.Infinity;

    private bool isVisible = false;

    // TODO: move this somewhere else!
    public bool isShutterSpeedLow;

    private void Awake()
    {
        shutterAction.action.performed += PressShutterButton;
        shutterAction.action.canceled += ReleaseShutterButton;
    }

    private void Start()
    {
        cam = GameObject.Find("viewFinder").GetComponent<Camera>();
        col = GetComponent<Collider>();
        isShutterSpeedLow = true;
        lowShutterSpeedUI.enabled = true;
        highShutterSpeedUI.enabled = false;

    }

    private void Update()
    {
        if (lowerShutterSpeed.action.IsPressed() && (isShutterSpeedLow == false))
        {
            Debug.Log("A pressed");
            //lower the speed
            isShutterSpeedLow = true;
            highShutterSpeedUI.enabled = false;
            lowShutterSpeedUI.enabled = true;
        }

        if(increaseShutterSpeed.action.IsPressed() && (isShutterSpeedLow))
        {
            //increase the speed
            Debug.Log("B pressed");
            isShutterSpeedLow = false;
            lowShutterSpeedUI.enabled = false;
            highShutterSpeedUI.enabled = true;
        }

        var bounds = col.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            RaycastHit hit;

            Vector3 direction = col.transform.position - cam.transform.position;
            if (Physics.Raycast(cam.transform.position, direction, out hit))
            {
                if (hit.collider && GameObject.ReferenceEquals(hit.collider.gameObject, gameObject))
                {
                    // If the object is within the camera's view frustum AND is not blocked by any other object, it is visible
                    isVisible = true;
                }
            }
        }
        else
        {
            isVisible = false;
        }

        //if the object is visible in camera and shutter speed is set to low
        if (isVisible && isShutterSpeedLow)
        {
            if (Time.time >= timeStamp)
            {
                SpawnObject();
                timeStamp = Time.time + interval;
            }
        }
        else if (isVisible && isShutterSpeedLow == false) // ---"--- and shutter speed is set to high
        {
            if (shutterAction.action.IsPressed())
            {
                    // TODO: Freeze object for a few seconds, not permanently
                    GetComponent<Movable>().isMoving = false;  
            }
        }
    }

    private void SpawnObject()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = transform.position;
    }

    public void PressShutterButton(InputAction.CallbackContext context)
    {
        timeStamp = Time.time + interval;
    }

    public void ReleaseShutterButton(InputAction.CallbackContext context)
    {
        timeStamp = Mathf.Infinity;
    }
}
