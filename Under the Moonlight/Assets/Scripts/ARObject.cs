using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObject : MonoBehaviour
{

[SerializeField]
#if UNITY_EDITOR
[Help("two animator bools are required: triggerAnimation & captured", UnityEditor.MessageType.None)]
#endif
float inspectorField = 1440f;

private Animator animator;
private bool alreadyCaptured = false;
private bool startedCapture = false;

public string whichLantern;

public Animator shroud;
private float shroudDist;
public float shroudRange = 5f;

private GameObject playerCam;

private GameObject ghostLantern;
private Renderer lanternRenderer;

public bool beingHit = false;
public Renderer thisMaterial;

public float captureTime = 3f;
private float realCaptureTime;

    void Start()
    {
        realCaptureTime = captureTime;
        animator = GetComponent<Animator>();
        ghostLantern = GameObject.FindWithTag(whichLantern);
        lanternRenderer = ghostLantern.GetComponent<Renderer>();
        lanternRenderer.enabled = false;
        playerCam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckShroudDistance();

        if ((beingHit == true) && (alreadyCaptured == false)){
            animator.SetInteger("animState", 1);
            thisMaterial.material.SetColor("_BaseColor", Color.red);
            //DetectionUI.detectionUIOn = true;
            StartCapture();
        }

        if (beingHit == false){
            animator.SetInteger("animState", 0);
            thisMaterial.material.SetColor("_BaseColor", Color.white);
            //DetectionUI.detectionUIOn = false;
            realCaptureTime = captureTime;
        }

        
    }

    public void StartCapture(){
    
    realCaptureTime -= Time.deltaTime;
 
    if (realCaptureTime <= 0.0f)
    {
        CaptureObject();
    }

    }

    public void CaptureObject(){
        animator.SetInteger("animState", 2);
        alreadyCaptured = true;
        lanternRenderer.enabled = true;
        Debug.Log("captured");
        //gameObject.tag=(null);
        shroud.SetInteger("shroudState", 2);
        StartCoroutine(ObjectShutdown());
    }

    public void CheckShroudDistance(){

    if (shroud != null){

        shroudDist = Vector3.Distance(gameObject.transform.position, playerCam.transform.position);

        if (shroudDist < shroudRange){      
            shroud.SetInteger("shroudState", 1);
            Debug.Log("inrange");
        }

        else{
            shroud.SetInteger("shroudState", 0);

        }

    }
    }

    IEnumerator ObjectShutdown(){
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
