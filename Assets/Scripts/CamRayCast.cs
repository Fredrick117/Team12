using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CamRayCast : MonoBehaviour
{
    private Interactable interactable;

    private RaycastHit hit;
    private bool isFanVisible;

    private GameObject Fan;
    private Animator fanAnim;

    [SerializeField] private TextMeshProUGUI lowShutterSpeedText;
    [SerializeField] private TextMeshProUGUI highShutterSpeedText;

    [SerializeField] private InputActionProperty capture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    void RayCast()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if(hit.collider.gameObject.tag == "Fan")
            {
                Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
                isFanVisible = true;
                Fan = hit.collider.gameObject;
                fanAnim = Fan.GetComponent<Animator>();
                Debug.Log("Fan milgaya");
            }
            else
            {
                isFanVisible=false;
                Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10);
            }
        }

        if(capture.action.IsPressed() && isFanVisible && highShutterSpeedText.enabled == true)
        {
            fanAnim.enabled = false;
        }
        
    }
}
