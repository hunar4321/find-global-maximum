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
            var new_agent = Instantiate(agent, new Vector3(x, y, z), Quaternion.identity);
            AssignColor(new_agent);

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
        
    }
}
