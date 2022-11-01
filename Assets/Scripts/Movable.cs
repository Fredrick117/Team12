using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test class that moves to and from start/end positions at a set speed.
public class Movable : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private Transform endPos;

    public bool isMoving = true;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed * Time.deltaTime);
    }

    private void Awake()
    {
        endPos = transform.GetChild(0);
    }
}
