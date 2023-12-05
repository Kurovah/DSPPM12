using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public GameObject playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerCharacter, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.up, 1);
        Gizmos.DrawLine(transform.position + Vector3.up, transform.position + Vector3.up + Vector3.forward * 5);
    }
}
