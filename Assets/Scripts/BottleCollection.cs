using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BottleCollection : MonoBehaviour
{
    public AudioSource audio;
    public Volume volume;
    VolumeProfile profile;
    public int Bottle = 0;

    bool hasBlurredVision;
    void Start()
    {
        profile = volume.sharedProfile; 
    }
    public void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Bottle") 
        {
            Bottle++;
            SetDrunkEffects();
            Debug.Log(Bottle);
            audio.Play();
            Destroy(other.gameObject);
        }
    

    }
    public void Update()
    {
        UpdateDrunkenEffects();
    }
    void SetDrunkEffects()
    {
        hasBlurredVision = Bottle > 2 ? true : false;
    }
    void UpdateDrunkenEffects()
    {
        //update dof
        if (profile.TryGet<DepthOfField>(out var dof))
        {
            var nf = new VolumeParameter<float>();
            if (hasBlurredVision)
            {
                nf.value = HelperScripts.Remap(Mathf.Sin(Time.timeSinceLevelLoad * 2), -1, 1, 0.1f, 4);
                
            } else
            {
                nf.value = 4;
            }
            dof.focusDistance.SetValue(nf);
        }
        
    }
}




