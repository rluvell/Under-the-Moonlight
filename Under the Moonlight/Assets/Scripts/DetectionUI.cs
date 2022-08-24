using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionUI : MonoBehaviour
{
    // Start is called before the first frame update
public static bool detectionUIOn = false;
private Renderer heatMap;

public float heatMin = 0f;
public float heatMax = 0.5f;

private float heatAmount = 0f;
float t = 0.001f;


    void Start()
    {
        heatMap = GetComponent<Renderer>();
        heatMap.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionUIOn == true)
        {
            if (t < heatMax){
            heatMap.enabled = true;
            heatAmount = Mathf.Lerp(heatMin, heatMax, t);
            heatMap.material.SetFloat("_heatDistortion", heatAmount);
            t += 0.1f * Time.deltaTime;
            Debug.Log("heatMap on");
            }


            if (t > (heatMax - 0.05)){
            heatAmount = 0f;
            heatMap.material.SetFloat("_heatDistortion", heatAmount);
            heatMap.enabled = false;
            Debug.Log("heatMap Finished");
            }
        }

        if (detectionUIOn == false){
            heatAmount = 0f;
            heatMap.material.SetFloat("_heatDistortion", heatAmount);
            t = 0.001f;
            heatMap.enabled = false;
            Debug.Log("heatmap off");

        }
    }

    
}
