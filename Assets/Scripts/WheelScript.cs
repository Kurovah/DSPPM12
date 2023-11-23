using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WheelScript : MonoBehaviour
{
    public Transform grabbingHand,Wheel;
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
            Wheel.up = Vector3.Cross(grabbingHand.position - transform.position, Wheel.right);
        }
    }

    public void OnGrabbed(SelectEnterEventArgs enterEventArgs)
    {
        Debug.Log("Grabbed");
        grabbingHand = enterEventArgs.interactorObject.transform;
        isGrabbed = true;
    }
}
