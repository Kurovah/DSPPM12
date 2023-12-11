using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelScript : MonoBehaviour
{
    public Transform grabbingHand,Wheel,root, testCube;
    bool isGrabbed;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGrabbed)
        {
            //Plane pl = new Plane(root.up, root.position + root.forward);
            //Vector3 p1 = pl.ClosestPointOnPlane(grabbingHand.position);
            ////testCube.position = p1;
            //Vector3 convP = root.InverseTransformPoint(p1);
            //angle = Vector3.SignedAngle(Vector3.up, p1 - root.position, -root.forward);
            //Wheel.localEulerAngles = new Vector3(- 90 + angle, 0, 90);

            Vector3 p = root.InverseTransformPoint(grabbingHand.position);
            angle = Mathf.Clamp(HelperScripts.Remap(p.y, -1.5f, 1.5f, -90, 90), -90, 90);
            Wheel.localEulerAngles = new Vector3(-90 - angle, 90, -90);
        }
        

    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("Grabbed");
        grabbingHand = args.interactorObject.transform;
        isGrabbed = true;
    }


    public void OnReleased(SelectExitEventArgs args)
    {
        grabbingHand = null;
        isGrabbed = false;
        Wheel.localEulerAngles = new Vector3(-90, 90, -90);
    }
    public float GetTurnAmount()
    {
        return Mathf.Clamp(HelperScripts.Remap(angle, -90, 90, -2, 2), -2, 2);
    }

}
