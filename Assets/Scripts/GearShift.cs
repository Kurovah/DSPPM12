using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GearShift : MonoBehaviour
{
    public Transform grabbingHand, stick, rootPos;
    bool isGrabbed;
    public CinemachinePathBase track;
    public CinemachineDollyCart stickCart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            float closest = track.FindClosestPoint(grabbingHand.position, 0,100,5);
            stickCart.m_Position = closest;
        }
    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("Grabbed");
        grabbingHand = args.interactorObject.transform;
        isGrabbed = true;
    }

    public float GetAccelAmount()
    {
        return stickCart.m_Position;
    }
}
