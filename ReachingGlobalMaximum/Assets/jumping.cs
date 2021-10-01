using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    Rigidbody rb;
    Renderer rd;
    public GameObject agent;
    public Transform foot;
    public LayerMask ground;
    public LayerMask water;
    float raydist = 1.1f; //distance from center of the capusl to the ground is 1
    float raydistWater = 0.8f;
    bool liberal = false;

    int Xmove = 0;
    int Ymove = 0;
    int Zmove = 0;

    float oldState = 0;
    float newState = 0;
    Vector3 pos;
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
    void Start()
    {
        
        rb = agent.GetComponent<Rigidbody>();
        Color cc = agent.GetComponent<Renderer>().material.color;

        if (cc.b > 0.5){ liberal = true; }else{ liberal = false; }

        MutateDirection();
        oldState = agent.transform.position.y;
        pos = new Vector3(agent.transform.position.x, 0, agent.transform.position.z); // agent.transform.position;
        rb.AddForce(Xmove, Ymove, Zmove);
        
    }

    void Update()
    {
        if (IsGrounded())
        {
            rb.velocity = Vector3.zero;
            Debug.DrawLine(pos, agent.transform.position, Color.yellow, 1000f);
            pos = agent.transform.position;
            Algorthim2();
        }
        if (IsInWater()){
            Destroy(agent);
        }
    }

    void Algorthim1()
    {
        rb.AddForce(Xmove, Ymove, Zmove);
        MutateDirection();
    }

    void Algorthim2()
    {
        rb.AddForce(Xmove, Ymove, Zmove);
        newState = agent.transform.position.y;

        if (newState <= oldState)
        {
            MutateDirection();
        }
        oldState = newState;
    }

    void MutateDirection()
    {
        if (liberal == false)
        {
            int step = 100;
            Xmove = Random.Range(-step, step); //x
            Ymove = Random.Range(step, step*2); //y jump
            Zmove = Random.Range(-step, step); //z
        }
        else
        {
            int step = 400;
            Xmove = Random.Range(-step, step); //x
            Ymove = Random.Range(step-100, step+100); //y jump
            Zmove = Random.Range(-step, step); //z
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(foot.transform.position, 0.3f, ground);
        //return Physics.Raycast(agent.transform.position, Vector3.down, raydist);
    }

    bool IsInWater()
    {
        //return Physics.Raycast(agent.transform.position, Vector3.down, raydistWater);
        return Physics.CheckSphere(foot.transform.position, 0.1f, water);
    }
}
