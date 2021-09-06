using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject cam0;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject Terrain;
    private bool bighillVisible = false;

    // Start is called before the first frame update

    void Start()
    {
        cam0.SetActive(false);
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
        
        Terrain.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Mouse2))
        {

            cam0.SetActive(true);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam0.SetActive(false);
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            cam5.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            cam5.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cam0.SetActive(false);
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            cam5.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (bighillVisible == false)
            {
                Terrain.SetActive(true);
                bighillVisible = true;
            }
            else
            {
                Terrain.SetActive(false);
                bighillVisible = false;
            }
        }

    }
}
