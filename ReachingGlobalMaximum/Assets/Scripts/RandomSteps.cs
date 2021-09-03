using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSteps : MonoBehaviour
{
    Rigidbody rb;
    public GameObject agent;
    public Transform foot;

    public LayerMask ground;

    int xzRange = 200;
    int[] yRange = { 100, 300 };

    int[] dir= { 100, 200, 0 };
    float level1;
    float level2;


    void Start()
    {
        Application.targetFrameRate = 30;
        rb = agent.GetComponent<Rigidbody>();
        MutateDirection(dir);
        level1 = agent.transform.position.y;
        rb.AddForce(dir[0], dir[1], dir[2]);

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)){
            Algorthim2();
        //}

    }

    void Algorthim0()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("is grounded");
            Debug.Log(dir[0]);
            rb.AddForce(dir[0], dir[1], dir[2]);
            MutateDirection(dir);
        }
    }


    void Algorthim1()
    {
        if (IsGrounded())
        {
            rb.AddForce(dir[0], dir[1], dir[2]);
            MutateDirection(dir);
        }
    }

    void Algorthim2()
    {
        if (IsGrounded())
        {
            level2 = agent.transform.position.y;
            rb.AddForce(dir[0], dir[1], dir[2]);

            if (level2 <= level1)
            {
                //Debug.Log("Dir Changed");
                MutateDirection(dir);
            }
            //Debug.Log("level1: " + level1.ToString() + " level2: " + level2.ToString());
            level1 = level2;
        }
    }



    void MutateDirection(int[] dir)
    {
        dir[0] = Random.Range(-xzRange, xzRange); //x
        dir[1] = Random.Range(yRange[0], yRange[1]); //y jump
        dir[2] = Random.Range(-xzRange, xzRange); //z
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(foot.position, 0.1f, ground);
    }
}
