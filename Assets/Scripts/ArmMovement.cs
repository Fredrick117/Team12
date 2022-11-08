using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 150)
        {
            transform.position = startPos;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);
        }
    }
}
