using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_cctv : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject screenRenderers ;

    
    public bool isCamOn;
    private Camera renderCamera = null;
    private Component[] screenRenderer;
    private void Awake()
    {
        renderCamera = GetComponentInChildren<Camera>();
        

    }

    private void Start()
    {
        Component[] screenRenderer = screenRenderers.GetComponentsInChildren<MeshRenderer>();
        //foreach (MeshRenderer child in screenRenderer)
        //{
        //    print(child);
           
        //    //child is your child transform
        //}
        RenderTexture newTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        newTexture.antiAliasing = 4;

        renderCamera.targetTexture = newTexture;

        foreach (MeshRenderer child in screenRenderer)
        {

            child.material.mainTexture = newTexture;
            //child is your child transform
        }
        TurnOn();

    }

    private void CreateRenderTexture()
    {
        
        
    }

    private Texture2D RenderCameraToTexture(Camera camera)
    {
        camera.Render();
        RenderTexture.active = camera.targetTexture;

        Texture2D photo = new Texture2D(256, 256, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        photo.Apply();

        return photo;
    }
    // Update is called once per frame
   

    public void TurnOn()
    {
        Component[] screenRenderer = screenRenderers.GetComponentsInChildren<MeshRenderer>();
        renderCamera.enabled = true;
        foreach (MeshRenderer child in screenRenderer)
        {
            print(child);
            child.material.color = Color.white;
            //child is your child transform
        }

        
        isCamOn = true;
    }

    public void TurnOff()
    {
        renderCamera.enabled = false;
        foreach (MeshRenderer child in screenRenderer)
        {
            child.material.color = Color.black;
            //child is your child transform
        }
        
        isCamOn = false;
    }
}
