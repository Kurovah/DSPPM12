using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GearShift : MonoBehaviour
{
    public Transform grabbingHand, stick, rootPos;
    bool isGrabbed;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            Vector3 projectionVec = grabbingHand.position - rootPos.position;
            Vector3 normal = rootPos.right;
            Vector3 newPos = Vector3.Project(projectionVec, normal);
            newPos.y = newPos.z = 0; ;
            stick.position = rootPos.position + newPos;
        }
    }

    public void OnGrabbed(SelectEnterEventArgs enterEventArgs)
    {
        Debug.Log("Grabbed");
        grabbingHand = enterEventArgs.interactorObject.transform;
        isGrabbed = true;
    }
}
