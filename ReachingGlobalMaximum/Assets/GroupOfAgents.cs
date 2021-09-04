using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfAgents : MonoBehaviour
{

    public GameObject agent;
    public int num = 100;
    //private GameObject[] agents;
    private void Awake()
    {
        Application.targetFrameRate = 30;
        //agents = new GameObject[num];
    }


    void Start()
    {
        for (int i = 0; i < num; ++i)
        {

            int x = Random.Range(450, 500);
            int y = Random.Range(50, 100);
            int z = Random.Range(160, 330);
            var agents = Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
            AssignColor(agents);
            
        }
    }

    void AssignColor(GameObject agent)
    {
        int tossColor = Random.Range(0, 3);
        var rd = agent.GetComponent<Renderer>();
        if (tossColor == 0) { rd.material.color = Color.black;}
        else if(tossColor == 1){ rd.material.color = Color.yellow;}
        else{ rd.material.color = Color.blue; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var numAlive = GameObject.FindGameObjectsWithTag("Player").Length;
            Debug.Log("Alive:" + numAlive);

            var tobeBorn = num - numAlive;
            for(int i=0; i<tobeBorn; i++)
            {
                int x = Random.Range(450, 500);
                int y = Random.Range(50, 100);
                int z = Random.Range(160, 330);
                var agents = Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
                AssignColor(agents);
                Debug.Log("New Born:" + tobeBorn);
            }


            //Debug.Log("hello");
            //int x = Random.Range(450, 500);
            //int y = Random.Range(50, 100);
            //int z = Random.Range(160, 330);
            //var agents = Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
            //AssignColor(agents);
          
        }

    }
}
