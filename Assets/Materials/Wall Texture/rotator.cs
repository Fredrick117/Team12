using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{

    public float degreesPerSecond = 20.0f;
    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime, 0,  0);
    }
}
