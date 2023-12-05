using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelScript : MonoBehaviour
{
    public Transform grabbingHand,Wheel,root;
    bool isGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGrabbed)
        {
            Plane pl = new Plane(Wheel.up, root.position + Wheel.forward);
            Vector3 p1 = pl.ClosestPointOnPlane(grabbingHand.position);
            Vector3 convP = root.InverseTransformPoint(p1);
            float angle = Vector3.Angle(Vector3.up, p1 - root.position);
            Wheel.localEulerAngles = new Vector3((angle - 90) * Vector3.Dot(Wheel.forward, p1 - root.position), 0, 90);
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
        Wheel.localEulerAngles = new Vector3(0, 0, 90);
    }
    public float GetTurnAmount()
    {
        return Mathf.Clamp(HelperScripts.Remap(Wheel.localRotation.eulerAngles.x, 180, 0, -1, 1), -1, 1);
    }

}
