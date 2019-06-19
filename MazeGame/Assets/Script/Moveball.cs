using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveball : MonoBehaviour
{
    public float movespeed;
    public Rigidbody rigidbody;

    private Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidbody.AddForce(input * movespeed);
    }
}
