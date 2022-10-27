using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DollyZoom : MonoBehaviour
{
    public XRNode inputSource;
    private Vector2 inputAxis;
    private float zoomSpeed = 10f;

    private Camera camera;
    public Transform target;

    private float initFrusHeight;
    /*private float initHeightAtDist;
    private bool dzEnabled;


    // Calculate the frustum height at a given distance from the camera.
    float FrustumHeightAtDistance(float distance)
    {
        return 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    // Calculate the FOV needed to get a given frustum height at a given distance.
    float FOVForHeightAndDistance(float height, float distance)
    {
        return 2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg;
    }

    // Start the dolly zoom effect.
    void StartDZ(float input)
    {
        var distance = Vector3.Distance(transform.position, target.position);
        initHeightAtDist = FrustumHeightAtDistance(distance);
        dzEnabled = true;

        if (dzEnabled)
        {
            // Measure the new distance and readjust the FOV accordingly.
            var currDistance = Vector3.Distance(transform.position, target.position);
            camera.fieldOfView = FOVForHeightAndDistance(initHeightAtDist, currDistance * input);
        }
    }*/
    private float ComputeFrustumHeight(float distance)
    {
        return (2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    private float ComputeFieldofView(float height, float distance)
    {
        return (2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg);
    }

    private void Awake()
    {
        camera = GetComponent<Camera>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);
        initFrusHeight = ComputeFrustumHeight(distanceFromTarget);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Trying to zoom");
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        //StartDZ(inputValue.x);
        if(inputAxis.magnitude != 0)
        {
            Debug.Log(inputAxis.y);
            transform.Translate(inputAxis.y * Vector3.forward * Time.deltaTime * zoomSpeed);

            float currentDis = Vector3.Distance(transform.position, target.position);
            camera.fieldOfView = ComputeFieldofView(initFrusHeight, currentDis);
            Debug.Log("Zoomed");
        }

    }
}
