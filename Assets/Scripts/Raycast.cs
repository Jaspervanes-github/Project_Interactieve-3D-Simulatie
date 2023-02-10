using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {
    public Camera camera;
    Transform objectHit;

    void Start(){
        objectHit = GameObject.Find("A1").transform;
        Debug.Log("Object Initialized: " + objectHit);
    }

    void Update(){
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("Something got hit! ObjectHit: " + objectHit);
                //Check if object hit has a Highlight component
                // if(objectHit != null && hit.collider.GetComponent<Highlight>() != null){
                if(hit.collider.GetComponent<Highlight>() != null){
                //     //Remove highlight from previous higlighted object
                    objectHit.GetComponent<Highlight>()?.ToggleHighlight(false);
                    objectHit = hit.transform;

                // Highlight the hit object
                Debug.Log("Ray Hit: " + objectHit);
                objectHit.GetComponent<Highlight>()?.ToggleHighlight(true);
                }
            }
        }
    }
}