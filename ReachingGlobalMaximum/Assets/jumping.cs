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


    int xzRange = 100;
    int[] yRange = { 100, 200 };

    int[] dir = { 100, 200, 0 };
    float level1;
    float level2;
    Vector3 pos;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
    void Start()
    {
        
        rb = agent.GetComponent<Rigidbody>();
        //agent.GetComponent<Renderer>().material.color = Color.black;
        
        MutateDirection(dir);
        level1 = agent.transform.position.y;
        pos = agent.transform.position;
        rb.AddForce(dir[0], dir[1], dir[2]);
        
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
    }

    void Algorthim1()
    {
        rb.AddForce(dir[0], dir[1], dir[2]);
        MutateDirection(dir);
    }

    void Algorthim2()
    {
        level2 = agent.transform.position.y;
        rb.AddForce(dir[0], dir[1], dir[2]);

        if (level2 <= level1)
        {
            MutateDirection(dir);
        }
        level1 = level2;
    }

    void MutateDirection(int[] dir)
    {
        dir[0] = Random.Range(-xzRange, xzRange); //x
        dir[1] = Random.Range(yRange[0], yRange[1]); //y jump
        dir[2] = Random.Range(-xzRange, xzRange); //z
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(foot.transform.position, 0.3f, ground);
    }
}
