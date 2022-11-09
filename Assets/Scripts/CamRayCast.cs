using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Resources;

public class CamRayCast : MonoBehaviour
{
    private Interactable interactable;

    private RaycastHit hit;
    private bool isFanVisible;
    private bool isArmVisible;
    private bool isWallVisible;

    private GameObject Fan;
    private Animator fanAnim;
    private BoxCollider fanCollider;

    private GameObject Wall;
    private objectMove wallMoveScript;

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
                isFanVisible = true;
                Fan = hit.collider.gameObject;
                fanCollider = Fan.GetComponent<BoxCollider>();
                fanAnim = Fan.GetComponent<Animator>();
                //Debug.Log(Fan.gameObject.name + " milgaya");
            }
            else
            {
                isFanVisible=false;
            }

            //if raycast hits moving arm
            if (hit.collider.gameObject.tag == "Arm")
            {
                isArmVisible = true;
                arm = hit.collider.gameObject;
                //Debug.Log(arm.gameObject.name + " milgaya");
            }
            else
            {
                isArmVisible = false;
            }

            //if raycast hits wall
            if(hit.collider.gameObject.tag == "Wall")
            {
                isWallVisible = true;
                Wall = hit.collider.gameObject;
                wallMoveScript = Wall.GetComponent<objectMove>();
            }
            else
            {
                isWallVisible = false;
            }
        }

        if(capture.action.IsPressed() && highShutterSpeedText.enabled == true)
        {
            if (isFanVisible)
            {
                //Debug.Log(capture.action.IsPressed());
                fanAnim.enabled = false;
                fanCollider.enabled = false;
                StartCoroutine(ResetFan(5f, fanAnim, fanCollider));
            }
            else if (isArmVisible)
            {
                arm.GetComponent<ArmMovement>().enabled = false;
                StartCoroutine(ResetArm(5f, arm));
            }
            else if(isWallVisible)
            {
                wallMoveScript.enabled = false;
                StartCoroutine(ResetWall(5f, wallMoveScript));
            }
            
        }
        
    }

    //Fan rotates again
    IEnumerator ResetFan(float delay, Animator fan, BoxCollider fancollider)
    {
        yield return new WaitForSeconds(delay);
        
        if(fan.enabled == false && fancollider.enabled == false)
        {
            //Debug.Log("Resetting fan");
            fan.enabled = true;
            fancollider.enabled = true; 
        }
    }

    //Arm moves again
    IEnumerator ResetArm(float delay, GameObject arm)
    {
        yield return new WaitForSeconds(delay);

        if (arm.GetComponent<ArmMovement>().enabled == false)
        {
            //Debug.Log("Restting arm");
            arm.GetComponent<ArmMovement>().enabled = true;
        }
    }

    //Wall moves again
    IEnumerator ResetWall(float delay, objectMove wallmover)
    {
        yield return new WaitForSeconds(delay);

        if(wallmover.enabled == false)
        {
            wallmover.enabled = true;
        }
    }
}
