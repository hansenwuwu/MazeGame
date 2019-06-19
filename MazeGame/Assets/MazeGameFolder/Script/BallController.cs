using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballForce = 10000f;
    private GameObject ball;
    private Rigidbody m_rig;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        m_rig = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Rabbit"){
            m_rig.AddForce(-Vector3.forward * ballForce);
        }
    }

}
