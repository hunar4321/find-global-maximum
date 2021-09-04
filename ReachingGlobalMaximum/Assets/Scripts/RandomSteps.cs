using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAgents
{
    
}

public class RandomSteps : MonoBehaviour
{
    Rigidbody rb;
    public GameObject agent;
    public Transform foot;
    //public int waitTime = 10;
    public int num = 100;

    private GameObject[] agents;
    private Rigidbody[] rbs;
    int[] dirx, diry, dirz;
    float[] levels1, levels2;


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
        //agents = new GameObject[num];
        //rbs = new Rigidbody[num];
        //levels1 = new float[num];
        //levels2 = new float[num];
        //dirx = new int[num];
        //diry = new int[num];
        //dirz = new int[num];

    }
    void Start()
    {


        //for (int i = 0; i < 100; ++i)
        //{
            
        //    int x = Random.Range(0, 500);
        //    int y = Random.Range(50, 200);
        //    int z = Random.Range(0, 500);
        //    agents[i] = Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
            
        //    rbs[i] = agents[i].GetComponent<Rigidbody>();
        //    MutateDirection(dir, dirx, diry, dirz);
        //    levels1[i] = agents[i].transform.position.y;
        //    rbs[i].AddForce(dir[0], dir[1], dir[2]);
        //}

        rb = agent.GetComponent<Rigidbody>();
        MutateDirection(dir, dirx, diry, dirz);
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

        //for(int i=0; i<num; i++)
        //{
        //    rbs[i].velocity = Vector3.zero;
        //}
        //Algorthim2();
        
    }

    void Algorthim1()
    {
        rb.AddForce(dir[0], dir[1], dir[2]);
        MutateDirection(dir, dirx, diry, dirz);
    }

    void Algorthim2()
    {
        level2 = agent.transform.position.y;
        rb.AddForce(dir[0], dir[1], dir[2]);

        if (level2 <= level1)
        {
            MutateDirection(dir, dirx, diry, dirz);
        }
        level1 = level2;
    }

    void MutateDirection(int[] dir, int[] dirx, int[] diry, int[] dirz)
    {
        dir[0] = Random.Range(-xzRange, xzRange); //x
        dir[1] = Random.Range(yRange[0], yRange[1]); //y jump
        dir[2] = Random.Range(-xzRange, xzRange); //z

        //for(int i=0; i<num; i++)
        //{
        //    dirx[i] = Random.Range(-xzRange, xzRange); //x
        //    diry[i] = Random.Range(yRange[0], yRange[1]); //y jump
        //    dirz[i] = Random.Range(-xzRange, xzRange); //z
        //}
    }

    bool IsGrounded()
    {
        //var foot = agent.GetComponentInChildren<GameObject>();
        return Physics.CheckSphere(foot.transform.position, 0.3f, ground);
    }
}
