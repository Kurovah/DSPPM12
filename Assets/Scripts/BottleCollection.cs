using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BottleCollection : MonoBehaviour
{
    public AudioSource audioSource;
    public int Bottle = 0;
    public TextMeshProUGUI bottleText;
    public TMP_Text text;
    public Volume screenEffectVol;
    DepthOfField dofFX;

    bool isDrunk;

    private void Start()
    {
        DepthOfField tmpDof;
        screenEffectVol.profile.TryGet<DepthOfField>(out tmpDof);
        dofFX = tmpDof;
        text.text = "Bottles: " + Bottle.ToString();
    }

    public void Update()
    {
        UpdateDizzyEffect();
    }

    public void OnTriggerEnter(Collider other) 
    {
        //print(other.gameObject.name);
        if(other.gameObject.tag == "Bottle") 
        {
            Bottle++;
            //bottleText.text = "Bottles: " + Bottle.ToString();
            if(text != null)
                text.text = "Bottles: " + Bottle.ToString();

            UpdateEffects();
            audioSource.Play();
            Destroy(other.gameObject);
        }
    }

    void UpdateDizzyEffect()
    {

        DepthOfField tmpDof;
        if (screenEffectVol.profile.TryGet<DepthOfField>(out tmpDof))
        {
            VolumeParameter<float> v = new VolumeParameter<float>();
            v.value = isDrunk ? Mathf.Sin(Time.timeSinceLevelLoad * 2) : 4;
            tmpDof.focusDistance.SetValue(v);
        } 
    }

    void UpdateEffects()
    {
        isDrunk = Bottle > 2;
    }
   
   }




