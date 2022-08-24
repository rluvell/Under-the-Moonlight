using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{

private Collider thisCollider;
private Animation thisAnimator;

    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider>();
        thisAnimator = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other){
        thisAnimator.Play();

    }
}
