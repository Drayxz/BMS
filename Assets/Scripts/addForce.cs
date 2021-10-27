using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addForce : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        VelocityUpdate();
    }

    void VelocityUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * .95f, ForceMode.Force);
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
