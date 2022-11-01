using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Camera cam;
    Plane[] cameraFrustum;
    Collider col;

    float interval = 0.1f;

    private float timeStamp = Mathf.Infinity;

    private bool isVisible = false;

    [SerializeField]
    private bool lowShutterSpeed = false;

    private void Start()
    {
        foreach(Camera c in Camera.allCameras)
        {
            if (c.name == "Camera")
                cam = c;
        }
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
            // TODO: isVisible
            // TODO: replace with VR trigger action
            if (Input.GetMouseButtonDown(0))
            {
                timeStamp = Time.time + interval;
            }
            if (Input.GetMouseButtonUp(0))
            {
                timeStamp = Mathf.Infinity;
            }
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
}
