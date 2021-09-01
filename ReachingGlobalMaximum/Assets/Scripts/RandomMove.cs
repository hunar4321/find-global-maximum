using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{

    Rigidbody rb;
    int xzRange = 200;
    int[] yRange = { 100, 300 };
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomWander();
        }
    }

    void RandomWander()
    {
        int xforce = Random.Range(-xzRange, xzRange);
        int zforce = Random.Range(-xzRange, xzRange);
        int yforce = Random.Range(yRange[0], yRange[1]);

        rb.AddForce(xforce, yforce, zforce);
    }
}
