using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfAgents : MonoBehaviour
{

    public GameObject agent;
    public int num = 100;
    public int xmin = 900;
    public int xmax = 1000;
    public int zmin = 124;
    public int zmax = 340;
    public int ymin = 15;
    public int ymax = 100;

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

            int x = Random.Range(xmin, xmax);
            int y = Random.Range(ymin, ymax);
            int z = Random.Range(zmin, zmax);
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
            var Players = GameObject.FindGameObjectsWithTag("Player");
            var numAlive = Players.Length;

            Debug.Log("Alive:" + numAlive);

            var tobeBorn = num - numAlive;
            for(int i=0; i<tobeBorn; i++)
            {
                // randomly choose on of the alive ones to have a child (a better way is to chose the one with longest life)
                int ind = Random.Range(0, numAlive);
                // determine the characters of the parent
                Color cc = Players[ind].GetComponent<Renderer>().material.color;
                Vector3 pos = Players[ind].transform.position;

                

                float x = pos.x; // Random.Range(xmin, xmax);
                float y = pos.y; // Random.Range(ymin, ymax);
                float z = pos.z; // Random.Range(zmin, zmax);
                var agents = Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
                
                //Color new_color = new Color(0, 0, 0, 0);
                //agents.GetComponent<Renderer>().material.SetColor("_Color", new_color);

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
