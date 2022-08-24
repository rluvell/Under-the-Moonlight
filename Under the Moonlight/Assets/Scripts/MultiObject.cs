using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObject : MonoBehaviour
{
    // Start is called before the first frame update
    public static int currentIteration = 0;

    public GameObject[] Objects;
    private GameObject child;

    void Awake(){
        child = Instantiate(Objects[currentIteration],this.transform.position, this.transform.rotation);
        child.transform.parent = gameObject.transform;
        currentIteration ++;
        Debug.Log(currentIteration); 
    }
}
