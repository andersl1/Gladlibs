using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeight : MonoBehaviour
{
    static Camera cam;
    public static float height;
    public static float width;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        height = cam.pixelHeight;
        width = cam.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
