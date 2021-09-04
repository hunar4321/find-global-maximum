using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfAgents : MonoBehaviour
{

    public GameObject agent;
    public int num = 100;
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }


    void Start()
    {
        for (int i = 0; i < 100; ++i)
        {

            int x = Random.Range(0, 500);
            int y = Random.Range(50, 200);
            int z = Random.Range(0, 500);
            Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
