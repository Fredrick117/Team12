using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMove : MonoBehaviour
{
 
    public float speed;

    public bool leftRight;

    public bool updown;

    public float upChangeTime;
    public float leftChangeTime;

    private float _upChangeTime;
    private float _leftChangeTime;

    private Vector3 startPosition;
    void Start()
    {
        _upChangeTime = upChangeTime;

        _leftChangeTime = leftChangeTime;

        startPosition=this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (leftRight)
        {
            this.transform.position= this.transform.position+new Vector3(0, 0, speed * Time.deltaTime);
            _leftChangeTime-=Time.deltaTime;
            if (_leftChangeTime <= 0) {
                _leftChangeTime = leftChangeTime;

                this.transform.position = startPosition;
            } 

        }

        if (updown)
        {
            this.transform.position= this.transform.position+new Vector3(speed * Time.deltaTime, 0, 0);
            _upChangeTime-= Time.deltaTime;
            if (_upChangeTime <= 0)
            {
                _upChangeTime = upChangeTime;

                this.transform.position = startPosition;
            }
        }




    }
    
}
