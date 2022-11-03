using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSine : MonoBehaviour
{

    public float offsetSpeed = 2.5f;
    private float timer;
    private float offset;
    public bool isNegative;
   
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
       timer += Time.fixedDeltaTime;
        if (isNegative)
        {
            offset = -Mathf.Sin(timer) * offsetSpeed;
        }
        else 
        {
            offset = Mathf.Sin(timer) * offsetSpeed;
        }

        this.transform.position += new Vector3(0,0,offset);
    }
}
