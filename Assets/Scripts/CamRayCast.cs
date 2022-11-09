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
    private bool isArmVisible;

    private GameObject Fan;
    private Animator fanAnim;

    private GameObject arm;

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
            //if raycast hits fan
            if(hit.collider.gameObject.tag == "Fan")
            {
                Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
                isFanVisible = true;
                Fan = hit.collider.gameObject;
                fanAnim = Fan.GetComponent<Animator>();
                Debug.Log(Fan.gameObject.name + " milgaya");
            }
            else
            {
                isFanVisible=false;
                Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10);
            }

            //if raycast hits moving arm
            if (hit.collider.gameObject.tag == "Arm")
            {
                Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
                isArmVisible = true;
                arm = hit.collider.gameObject;
                Debug.Log(arm.gameObject.name + " milgaya");
            }
            else
            {
                isArmVisible = false;
                Debug.DrawRay(transform.position, transform.forward, Color.yellow, 10);
            }
        }

        if(capture.action.IsPressed() && highShutterSpeedText.enabled == true)
        {
            if(isFanVisible)
            {
                Debug.Log(capture.action.IsPressed());
                fanAnim.enabled = false;
                Fan.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(ResetFan(5f, fanAnim));
            }
            else if(isArmVisible)
            {
                arm.GetComponent<ArmMovement>().enabled = false;
                StartCoroutine(ResetArm(5f, arm));
            }
            
        }
        
    }

    //Fan rotates again
    IEnumerator ResetFan(float delay, Animator fan)
    {
        yield return new WaitForSeconds(delay);
        
        if(fan.enabled == false)
        {
            Debug.Log("Resetting fan");
            fan.enabled = true;
        }
    }

    //Arm moves again
    IEnumerator ResetArm(float delay, GameObject arm)
    {
        yield return new WaitForSeconds(delay);

        if (arm.GetComponent<ArmMovement>().enabled == false)
        {
            Debug.Log("Restting arm");
            arm.GetComponent<ArmMovement>().enabled = true;
        }
    }
}
