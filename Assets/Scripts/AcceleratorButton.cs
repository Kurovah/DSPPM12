using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AcceleratorButton : MonoBehaviour
{
    public Transform button;
    bool isGrabbed, isPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        isPressed = !isPressed;
        Debug.Log("Button |Pressed");
        Vector3 lp = new Vector3();
        lp.z = isPressed ? -0.2f : -0.7f;
        button.localPosition = lp;

    }
    public void OnReleased(SelectExitEventArgs args)
    {
        
    }
    public float GetAccelAmount()
    {

        return isPressed ? 1 : 0;
        
        
    }
}
