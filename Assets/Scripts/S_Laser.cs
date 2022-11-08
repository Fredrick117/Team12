using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Laser : MonoBehaviour
{
    public door_open door;
    private Quaternion initRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ArmAttachment")
        {
            door.isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ArmAttachment")
        {
            door.isOpen = false;
        }
    }
}
