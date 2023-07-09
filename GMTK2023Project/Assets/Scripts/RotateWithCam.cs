using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCam : MonoBehaviour
{
    private GameObject cam;
    public GameObject dialogueCam;
    public float turnSpeed = 0.01f;
    private float t;
    private bool trigger = false;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    public void RotateToFront()
    {
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
    }

    private void Update()
    {
        if (trigger)
        {
            var target = new Vector3(0, dialogueCam.transform.eulerAngles.y, 0);
            t += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, target, t * turnSpeed);
        }
    }

    //need partner rotation
    public void RotateToPartner()
    {
        
        trigger = true;
        
    }
}
