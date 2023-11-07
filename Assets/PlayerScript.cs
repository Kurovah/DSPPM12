using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float moveForce, steeringSmoothness;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Steer(Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.W))
        {
            Accel();
        }

        
    }

    private void LateUpdate()
    {
        playerTransform.position = rb.position;
    }

    void Accel()
    {
        rb.AddForce(playerTransform.forward * moveForce);
        //rb.AddForce(playerTransform.forward * moveForce, ForceMode.Acceleration);
    }

    void Steer(float _Direction)
    {
        transform.forward = Vector3.Lerp(transform.forward, transform.right * _Direction, steeringSmoothness * Mathf.Abs(Mathf.Sign(rb.velocity.magnitude)) * Time.deltaTime);
    }
}
