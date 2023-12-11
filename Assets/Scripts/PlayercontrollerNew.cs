using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayercontrollerNew : MonoBehaviour
{
    public float checkDis, suspensionForce;

    public float maxThrust;
    float targetThrust;
    float thrust;

    public float maxTurn;
    float targetTurn;
    float turn;
    public float crashThreshold;

    public List<Transform> suspensionPoints;
    public Rigidbody rb;
    public CinemachineVirtualCamera virtualCamera;

    [Header("Car Parts")]
    public WheelScript wheel;
    public AcceleratorButton stick;

    public TMP_Text testText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheel = GetComponentInChildren<WheelScript>();
        stick = GetComponentInChildren<AcceleratorButton>();
    }

    private void Update()
    {
        if(stick.GetAccelAmount() > 0)
        {
            targetThrust = maxThrust * stick.GetAccelAmount();

            targetTurn = maxTurn * (1 - wheel.GetTurnAmount());
        }

        thrust = Mathf.Lerp(thrust, targetThrust, 0.8f * Time.deltaTime);targetThrust = 0;
        turn = Mathf.Lerp(turn, targetTurn, 0.95f * Time.deltaTime);targetTurn = 0;
        virtualCamera.m_Lens.FieldOfView = HelperScripts.Remap(thrust, 0, maxThrust, 60, 85);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce((transform.forward * thrust), ForceMode.Acceleration);
        transform.Rotate(new Vector3(0, turn, 0));
        RaycastHit hit;
        Ray r = new Ray(Vector3.zero, Vector3.down);
        foreach (Transform t in suspensionPoints)
        {
            r.origin = t.position;
            Physics.Raycast(r, out hit, checkDis, LayerMask.GetMask("Ground"));


            //apply up force if the wheel is hitting something
            if (hit.collider != null)
            {
                float suspensionMultiplier = HelperScripts.Remap(hit.distance, 0, checkDis, .8f,0.1f);
                rb.AddForceAtPosition(Vector3.up * suspensionForce * suspensionMultiplier, t.position);
            }
        }

        //remove drift
        Vector3 vel = rb.velocity, forward = transform.forward;
        rb.AddForce(forward - vel, ForceMode.Acceleration);
        //testText.text = rb.velocity.magnitude.ToString();
    }

    private void OnDrawGizmos()
    {
        foreach (Transform t in suspensionPoints)
        {
            Gizmos.DrawLine(t.position, t.position + Vector3.down * checkDis);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject == this.gameObject)
        {
            return;
        }

        
        if(collision.gameObject.CompareTag("Crash") && collision.relativeVelocity.magnitude > crashThreshold)
        {
            Debug.Log("Crash");
            SceneManager.LoadScene("DeathScene");
        }
    }
}
