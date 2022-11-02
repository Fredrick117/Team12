using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamRayCast : MonoBehaviour
{
    private RaycastHit hit;
    private bool onTarget = false;
    [SerializeField] private InputActionProperty captureAction;
    private Transform target;
    private float ogScale;
    private Vector3 targetScale;

    private float ogDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        Capture();
    }

    void RayCast()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if(hit.collider.gameObject.CompareTag("Volatile"))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
                onTarget = true;
                target = hit.transform;
                ogDistance = Vector3.Distance(transform.position, target.position);
                ogScale = target.localScale.x;
                targetScale = target.localScale;
                Debug.Log("Sphere milgaya");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10);
                onTarget = false;
                target = null;
            }
        }
        
    }

    void Capture()
    {
        float capAction = captureAction.action.ReadValue<float>();
        RaycastHit hit2;
        if(onTarget && capAction != 0 && target != null)
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit2, Mathf.Infinity))
            {
                float currDistance = Vector3.Distance(transform.position, target.position);
                float s = currDistance / ogDistance;
                targetScale.x = targetScale.y = targetScale.z = s;

                target.transform.localScale = targetScale * ogScale;
            }
        }
    }
}
