using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public InputActionReference shutterAction = null;

    public GameObject go_rightHand;

    Camera cam;
    Plane[] cameraFrustum;
    Collider col;

    float interval = 0.1f;

    private float timeStamp = Mathf.Infinity;

    private bool isVisible = false;

    // TODO: move this somewhere else!
    [SerializeField]
    private bool lowShutterSpeed = true;

    private void Awake()
    {
        shutterAction.action.performed += PressShutterButton;
        shutterAction.action.canceled += ReleaseShutterButton;
    }

    private void Start()
    {
        cam = GameObject.Find("viewFinder").GetComponent<Camera>();
        col = GetComponent<Collider>();
    }

    private void Update()
    {

        // Change shutter speed
        if (Input.GetKeyDown(KeyCode.V))
        {
            lowShutterSpeed = !lowShutterSpeed;
        }

        var bounds = col.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }

        if (isVisible && lowShutterSpeed)
        {
            if (Time.time >= timeStamp)
            {
                SpawnObject();
                timeStamp = Time.time + interval;
            }
        }
        else if (isVisible && !lowShutterSpeed)
        {
            if (Input.GetMouseButtonDown(0))
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
