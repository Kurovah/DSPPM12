using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelScript : MonoBehaviour
{
    public Transform grabbingHand,Wheel,Testblock;
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
            Plane pl = new Plane(Wheel.right, Wheel.position + Wheel.forward);
            Vector3 p1 = pl.ClosestPointOnPlane(grabbingHand.position);
            Testblock.position = p1;
            Wheel.forward = Vector3.Cross(Wheel.right, (p1 - Wheel.position).normalized);
        }

    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("Grabbed");
        grabbingHand = args.interactorObject.transform;
        isGrabbed = true;
    }

    public float GetTurnAmount()
    {
        return Mathf.Clamp(HelperScripts.Remap(Wheel.localRotation.eulerAngles.x, 180, 0, -1, 1), -1, 1);
    }

}
