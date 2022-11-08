using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTimeAlive = 5.0f;
    private float currentTimeAlive;

    private void Awake()
    {
        currentTimeAlive = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeAlive < maxTimeAlive)
        {
            currentTimeAlive += Time.deltaTime;
        }
        else
        {
            print("cya!");
            Destroy(gameObject);
        }
    }
}
