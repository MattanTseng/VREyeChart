using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera look is only used for the desktop version of the application. 
// moves the viewing camera to follow the mouse.
public class CameraLook : MonoBehaviour
{
    public GameObject Viewer;
    float camSense = 0.25f; // How sensitive is the mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); // Kind of the middle of the screen rather than at teh tope

    private void Start()
    {

        Viewer = this.gameObject;
    }

    private void Update()
    {
        if(lastMouse != Input.mousePosition)
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSense, lastMouse.x * camSense, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            Viewer.transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }
    }

}
