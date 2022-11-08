using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Laser : MonoBehaviour
{
    [SerializeField] private Transform doorTransform;
    private Quaternion initRotation;
    // Start is called before the first frame update
    void Start()
    {
        initRotation = doorTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "ArmAttachment")
        {
            doorTransform.Rotate(Vector2.up, -0.3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ArmAttachment")
        {
            doorTransform.rotation = initRotation;
        }
    }
}
