using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterRotation : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        this.transform.Rotate(speed, 0, 0);
        //this.transform.rotation = Quaternion.Euler(speed * time, this.transform.rotation.y, this.transform.rotation.z);
    }
}
