using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_disapper : MonoBehaviour
{
    public float howManyTime;

    public float currentTime;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (currentTime>=howManyTime) 
        {
            Destroy(this.gameObject);

        }
    }
}
