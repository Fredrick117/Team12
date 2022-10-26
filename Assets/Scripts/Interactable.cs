using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Camera camera;
    Plane[] cameraFrustum;
    Collider collider;

    private void Start()
    {
        camera = Camera.main;
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            print("visible!");
        }
        else
        {
            print("not visible!");
        }
    }
}
