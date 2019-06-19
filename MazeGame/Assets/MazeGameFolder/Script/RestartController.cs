using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartController : MonoBehaviour
{
    private GameObject ball;
    private Rigidbody ballRig;
    private Vector3 m_origBallPos;

    // Start is called before the first frame update
    void Start()
    {
        // ball trap
        ball = GameObject.Find("Ball");
        m_origBallPos = ball.transform.position;
        ballRig = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Rabbit"){
            restart();
        }
    }

    public void restart(){
        ball.transform.position = m_origBallPos;
        ballRig.velocity = Vector3.zero;
        ballRig.angularVelocity = Vector3.zero;
    }

}
