using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitControl : MonoBehaviour
{
    public float forwardSpeed = 1.0f;
    public float rotateSpeed = 10.0f;

    private Vector3 portalPosition = new Vector3(-7.2f, 0, -7.5f);
    private Vector3 finalPosition = new Vector3(6.5f, 0, 2.5f);
    private Animator m_animator;
    private Transform m_transform;
    private Vector3 m_origPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        m_transform = gameObject.GetComponent<Transform>();
        m_origPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        AnimatorStateInfo state = m_animator.GetCurrentAnimatorStateInfo(0);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        m_animator.SetFloat("Speed", v);

        if (state.fullPathHash == Animator.StringToHash("Base Layer.Run"))
        {
            m_transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }

        if (h > 0)
        {
            m_transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else if(h<0)
        {
            m_transform.Rotate(0, - rotateSpeed * Time.deltaTime, 0);
        }

    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Ball"){
            gameObject.transform.position = m_origPosition;
        }
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "Portal01") {
            gameObject.transform.position = portalPosition;
        }

        if(other.gameObject.name == "Portal02"){
            gameObject.transform.position = m_origPosition;
        }

        if(other.gameObject.name == "Lava"){
            gameObject.transform.position = m_origPosition;
        }

        if(other.gameObject.name == "LavaSuccess"){
            gameObject.transform.position = finalPosition;
            gameObject.transform.rotation = Quaternion.EulerAngles(0.0f, 0.0f, 0.0f);
        }

    }



}
