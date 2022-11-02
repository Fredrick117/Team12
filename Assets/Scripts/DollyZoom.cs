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
    float min;

    private float initFrusHeight;

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

    // Update is called once per frame            -
    void Update()
    {

        //Debug.Log("Trying to zoom");
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        //Debug.Log(inputAxis.y);

        Mathf.Clamp(transform.position.z, 0, 100f);

        if(inputAxis.y < 0 && transform.position.z > 0)
        {
            transform.Translate(inputAxis.y * Vector3.forward * Time.deltaTime * zoomSpeed, Space.Self);
        }

        if(inputAxis.y > 0)
        {
            transform.Translate(inputAxis.y * Vector3.forward * Time.deltaTime * zoomSpeed, Space.Self);
        }

        float currentDis = Vector3.Distance(transform.position, target.position);
        camera.fieldOfView = ComputeFieldofView(initFrusHeight, currentDis);
        //Debug.Log("Zoomed");
    }
}