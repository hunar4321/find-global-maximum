using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramesPerSecond : MonoBehaviour
{
    Rect fpsRect;
    GUIStyle style;
    float fps;
    
    void Start()
    {
        fpsRect = new Rect(20, 20, 400, 100);
        style = new GUIStyle();
        style.fontSize = 24;

        StartCoroutine(RecalculateFPS());
    }

    private IEnumerator RecalculateFPS()
    {
        while (true)
        {
            fps = 1 / Time.deltaTime;
            yield return new WaitForSeconds(1); 
        }
    }
   
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(fpsRect, "FPS:" + (int)fps, style);
    }
}
