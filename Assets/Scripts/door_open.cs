using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open : MonoBehaviour
{
    public bool isOpen;
    public float rotationAng;
    public float speed;

    private float start;
    // Start is called before the first frame update
    void Start()
    {
        //start = this.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        //print(rotationAng);
        /*if (isOpen)
        {
           
            if (this.transform.rotation.y >= rotationAng)
            {
                
                transform.Rotate(0, -speed, 0);
            }

        }
        else 
        {
            if (this.transform.rotation.y <= start)
            {
                transform.Rotate(0, speed, 0);
            }

        }*/

        

    }
}
