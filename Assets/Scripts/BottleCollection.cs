using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BottleCollection : MonoBehaviour
{
   public AudioSource audio;
   public int Bottle = 0;

    public void OnTriggerEnter(Collider other) 
   {
    print(other.gameObject.name);
    if(other.gameObject.tag == "Bottle") 
    {
Bottle++;
Debug.Log(Bottle);
audio.Play();
Destroy(other.gameObject);
    }
    

    }
   
   }




