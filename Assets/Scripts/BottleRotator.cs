using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRotator : MonoBehaviour
{
    public Transform model;
    public float rotationRate;
    float sinOffset;
    // Start is called before the first frame update
    void Start()
    {
        sinOffset = Random.value;
        model.Rotate(Vector3.up, Random.value * 360);
    }

    // Update is called once per frame
    void Update()
    {
        model.localPosition = new Vector3(0, 0.005f + Mathf.Abs(Mathf.Sin(Time.timeSinceLevelLoad + sinOffset) * 0.004f), 0);
        model.Rotate(Vector3.up, rotationRate * Time.deltaTime);
    }
}
