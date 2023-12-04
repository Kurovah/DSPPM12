using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class BottleCollection : MonoBehaviour
{
   public AudioSource audio;
   public int Bottle = 0;
   public TextMeshProUGUI bottleText;

    public void OnTriggerEnter(Collider other) 
   {
    print(other.gameObject.name);
    if(other.gameObject.tag == "Bottle") 
    {
Bottle++;
bottleText.text = "Bottles: " + Bottle.ToString();
Debug.Log(Bottle);
audio.Play();
Destroy(other.gameObject);
    }
    

    }
   
   }




