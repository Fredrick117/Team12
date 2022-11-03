using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI hudText;

    private void Start()
    {
        hudText.gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        hudText.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        hudText.gameObject.SetActive(false);
    }
}
