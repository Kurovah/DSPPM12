using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(car, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
