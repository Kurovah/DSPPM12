using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndMenu : MonoBehaviour
{
    public Image blackOut;
    // Start is called before the first frame update
    void Start()
    {
        blackOut.CrossFadeAlpha(0, 2, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
