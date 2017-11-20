using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;        //target to chase
    public float smoothing;         //smooth the movement
    Vector3 offset;                 //the offset
    float lowY;                     //the lowest pos
    float highY;                    //the highest pos
    // Use this for initialization
    void Awake() {
        transform.position = new Vector3(target.position.x+4, target.position.y+6, transform.position.z-5); //set the position of camera
    }

	void Start () {
        offset = transform.position - target.position;      //calculate offset
        lowY = transform.position.y;                        //set lowY
        highY = transform.position.y;                       //set highY

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);                        //update camera position
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);    
        if (transform.position.y > highY) transform.position = new Vector3(transform.position.x, highY, transform.position.z);
	}
}
