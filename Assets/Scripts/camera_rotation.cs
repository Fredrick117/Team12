using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float upChangeTime;
    public float leftChangeTime;

    public float speed;
 
    public bool leftRight;

    public bool updown;

    private float _upChangeTime;
    private float _leftChangeTime;
    private float is_up=1;
    private float is_left=1;
    void Start()
    {
        _upChangeTime = upChangeTime;

        _leftChangeTime = leftChangeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftRight) 
        {
            transform.Rotate(0, speed* is_left, 0);
            _leftChangeTime-=Time.deltaTime;
            if (_leftChangeTime <= 0)
            {
                
                _leftChangeTime = leftChangeTime;
                is_left = -is_left;
            }
           
            
        }

        if (updown)
        {
            transform.Rotate(speed* is_up, 0, 0);
            _upChangeTime -= Time.deltaTime;
            if (_upChangeTime <= 0)
            {

                _upChangeTime = upChangeTime;
                is_up = -is_up;
            }


        }




    }
}
