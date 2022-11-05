using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_rotation : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    public float max;
    public float min;
    private float radom;
    void Start()
    {
        radom=Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(radom * time, radom * time, radom * time);
    }
}
