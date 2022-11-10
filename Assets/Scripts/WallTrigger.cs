using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    [SerializeField] private GameObject wall1, wall2;
    // Start is called before the first frame update
    void Start()
    {
        wall1.GetComponent<objectMove>().enabled = false;
        wall2.GetComponent<objectMove>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            wall1.GetComponent<objectMove>().enabled = true;
            wall2.GetComponent<objectMove>().enabled = true;
        }
    }
}
