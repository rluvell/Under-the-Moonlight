using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class AutoPlacementOfObjectsInPlane : MonoBehaviour
{
    //[SerializeField]
    //private GameObject welcomePanel;

    [SerializeField]
    private GameObject[] placedPrefab;
    public int currentEntry = 0;
    public int maxEntries = 3;
    


    private GameObject placedObject;
    private float distance = 0f;
    public float minimumDistance = 200f;


    //[SerializeField]
    //private Button dismissButton;

    [SerializeField]
    private ARPlaneManager arPlaneManager;

    void Awake() 
    {
        //dismissButton.onClick.AddListener(Dismiss); //controls the button
        arPlaneManager = GetComponent<ARPlaneManager>(); //tells us which plane manager to use (doesn't need to be serialised then)
        arPlaneManager.planesChanged += PlaneChanged; //checks when a new plane is found event calls PlaneChanged
    }

    void Update(){
        //if (currentEntry > maxEntries){
           //arPlaneManager.planesChanged += PlaneChanged; //starts listening for the event when a new plane is identified, then calls PlaneChanged
        //}
    }



    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        ARPlane arPlane = args.added[0];
        distance = 0f;
        if (placedObject != null){
        distance += Vector3.Distance(arPlane.transform.position, placedObject.transform.position);
        }

        if (currentEntry == 0){
            placedObject = Instantiate(placedPrefab[currentEntry], arPlane.transform.position, Quaternion.identity);
            currentEntry ++;
            arPlaneManager.planesChanged += PlaneChanged;
            Debug.Log("placed first object");
        }

        if ((currentEntry > 0) & (currentEntry < maxEntries)){
        //do this code for subsequent objects
            if (distance > minimumDistance){
                //instance our object and advance
                placedObject = Instantiate(placedPrefab[currentEntry], arPlane.transform.position, Quaternion.identity);
                currentEntry ++;
                arPlaneManager.planesChanged += PlaneChanged;
                Debug.Log("placed another object");
            }

            if (distance <= minimumDistance){
                //don't instance and look again
                arPlaneManager.planesChanged += PlaneChanged;
                Debug.Log("plane too close didn't place");
            }
        }         

        /* if (currentEntry < maxEntries){
        ARPlane arPlane = args.added[0];

            if (currentEntry >)
            {
                distance += Vector3.Distance(arPlane.transform.position, placedObject.transform.position);

                if (distance > minimumDistance)
                {
                placedObject = Instantiate(placedPrefab[currentEntry], arPlane.transform.position, Quaternion.identity);
                currentEntry ++;
                Debug.Log("object far enough from previous, placed");
                distance = 0f;
                arPlaneManager.planesChanged += PlaneChanged;

                }

                if (distance < minimumDistance) {
                arPlaneManager.planesChanged += PlaneChanged;
                distance = 0f;
                Debug.Log("object too close didn't place, start again");
                }
            }

        if (currentEntry > 0) {
            placedObject = Instantiate(placedPrefab[currentEntry], arPlane.transform.position, Quaternion.identity);
            currentEntry ++;
            Debug.Log("placed first object");
            arPlaneManager.planesChanged += PlaneChanged;
            }
    } */

    }

    //public void Dismiss() => welcomePanel.SetActive(false); //turns off canvas when button is clicked

}
