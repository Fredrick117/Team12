using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;

    // The object that opens a door when hit by the laser
    [SerializeField]
    private GameObject receiver;

    // The door that is deleted when the receiver is activated
    [SerializeField]
    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        
        // Laser start is emitter's position, laser end is 50 units in the forward direction
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                // Kill player if hit by laser
                GameObject.Destroy(hit.collider.gameObject);
            }
            else if (ReferenceEquals(hit.collider.gameObject, receiver))
            {
                // Delete door when receiver is hit
                GameObject.Destroy(door);
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 50);
        }
    }
}
