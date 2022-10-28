using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRayCast : MonoBehaviour
{
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    void RayCast()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if(hit.collider.gameObject.CompareTag("Volatile"))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
                Debug.Log("Sphere milgaya");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10);
            }
        }
        
    }
}
