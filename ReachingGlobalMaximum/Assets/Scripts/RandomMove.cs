using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    Rigidbody rb;
    int xyRange = 200;
    int[] jumpRange = { 100, 300 };
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll)
    {
        RandomWander();
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
        float xforce = Random.Range(-xyRange, xyRange);
        float zforce = Random.Range(-xyRange, xyRange);
        float yforce = Random.Range(jumpRange[0], jumpRange[1]);
        rb.AddForce(xforce, yforce, zforce);
    }
}
