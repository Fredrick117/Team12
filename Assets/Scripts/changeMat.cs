using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMat : MonoBehaviour
{

    //in the editor this is what you would set as the object you wan't to change

    public word_disapper add;
    public Material Material1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "highLight")
        {
            
            collision.gameObject.GetComponent<MeshRenderer>().material = Material1;
            add.currentTime++;
        }

    }

}
