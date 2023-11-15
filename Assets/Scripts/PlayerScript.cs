using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Transform playerTransform;

    [Header("Max speed & turn angle")]
    public float maxSpeed;
    public float maxTurnSpeed;

    [Header("Smoothing")]
    public float turnSmoothing;
    public float speedsmoothing;

    float currentSpeed, targetSpeed, currentTurning, targetTurning;
    public Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetSpeed = Input.GetKey(KeyCode.W) ? maxSpeed : 0;
        targetTurning = (Input.GetAxis("Horizontal") != 0) ? maxTurnSpeed * Input.GetAxis("Horizontal") : 0;


        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, speedsmoothing);
        currentTurning = Mathf.Lerp(currentTurning, targetTurning, turnSmoothing);

    }

    private void FixedUpdate()
    {
        rb.AddForce(playerTransform.forward * currentSpeed, ForceMode.Acceleration);
        playerTransform.eulerAngles = Vector3.Lerp(playerTransform.eulerAngles, new Vector3(0, playerTransform.eulerAngles.y + currentTurning, 0), Time.deltaTime * 4);
    }

    private void LateUpdate()
    {
        playerTransform.position = rb.position;
    }

}
