using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GearShift : MonoBehaviour
{
    public Transform grabbingHand, stick, rootPos;
    bool isGrabbed;
    public CinemachinePathBase track;
    public CinemachineDollyCart stickCart;
    public PlayercontrollerNew playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayercontrollerNew>();
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
        if (!isGrabbed)
        {
            Debug.Log("Grabbed");
            grabbingHand = args.interactorObject.transform;
            isGrabbed = true;
        }
    }
    public void OnReleased(SelectExitEventArgs args)
    {
        grabbingHand = null;
        isGrabbed = false;
    }
    public float GetAccelAmount()
    {
        if (playerController.controlType == PlayercontrollerNew.ControlTypes.Keyboard)
        {
            return Input.GetAxis("Vertical");
        } else
        {
            return stickCart.m_Position;
        }
        
    }
}
