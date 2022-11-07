using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_oscillator : MonoBehaviour
{
    [SerializeField] private Transform resetTrigger;
    private float movSpeed = 3f;


    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(startingPos, resetTrigger.position, movSpeed * Time.deltaTime);

        if(transform.position == resetTrigger.position)
        {
            transform.position = startingPos;
        }
    }
}
