using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectDetector : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera playerCamera;
    public static bool hittingObj = false;

    private GameObject arObjectHit;
    private ARObject arObjectComponent;

    public static float maxRayDistance = 2f;




    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ARObjectDetection();
    }

    private void ARObjectDetection()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.4F, 0));
        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit, maxRayDistance)) && (hit.collider.tag == "ARObject"))
        {
            hittingObj = true;
            arObjectHit = hit.collider.gameObject;
            arObjectComponent = arObjectHit.GetComponent<ARObject>();
            arObjectComponent.beingHit = true;
            DetectionUI.detectionUIOn = true;
        }

        else{
                hittingObj = false;
            DetectionUI.detectionUIOn = false;

            if (arObjectComponent != null)
            {
                arObjectComponent.beingHit = false;
            }
        }
        
    }
    
}
