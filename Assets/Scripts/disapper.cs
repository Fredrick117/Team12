using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapper : MonoBehaviour
{
    // Start is called before the first frame update
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(this.gameObject);

        }
        
    }
   
}
