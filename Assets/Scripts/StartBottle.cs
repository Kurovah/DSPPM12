using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StartBottle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBottleGrabbed(SelectEnterEventArgs args)
    {
        //GameManager.instance.GoToScene("PlayScene");
        SceneManager.LoadSceneAsync("PlayScene");
    }
}
